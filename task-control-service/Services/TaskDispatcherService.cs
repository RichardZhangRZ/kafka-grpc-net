using Confluent.Kafka;
using Microsoft.Extensions.Options;
using System.Text.Json;
using task_control_service.Models;

namespace task_control_service.Services
{
    public class TaskDispatcherService : ITaskDispatcherService
    {
        private readonly IProducer<Null, string> _producer;

        public TaskDispatcherService(IOptions<KafkaConfiguration> kafkaConfig)
        {
            var producerconfig = new ProducerConfig
            {
                BootstrapServers = kafkaConfig.Value.BootstrapServers,
            };

            var producerBuilder = new ProducerBuilder<Null, string>(producerconfig);
            _producer = producerBuilder
                .Build();
        }

        public async Task<DispatchTaskResponse> DispatchTask(DispatchTaskRequest request)
        {
            var taskDetailsMessage = new TaskDetailsMessage()
            {
                Duration = request.Duration,
                Message = request.Message,
                RequesterUserId = request.RequesterUserId,
                TaskId = Guid.NewGuid()
            };

            var taskDetailsMessageString = JsonSerializer.Serialize(taskDetailsMessage);

            var deliveryResult = await _producer.ProduceAsync("task-requests", new Message<Null, string>() { Value = taskDetailsMessageString });

            var response = new DispatchTaskResponse
            {
                Message = $"Successfully dispatched the requested task",
                TaskDetails = taskDetailsMessage,
                Success = true
            };

            if (deliveryResult.Status != PersistenceStatus.Persisted)
            {
                response = new DispatchTaskResponse
                {
                    Message = $"Failed to dispatch the requested task",
                    TaskDetails = taskDetailsMessage,
                    Success = false
                };
            }

            return await Task.FromResult(response);
        }
    }
}
