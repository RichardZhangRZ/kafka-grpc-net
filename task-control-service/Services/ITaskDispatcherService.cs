using task_control_service.Models;

namespace task_control_service.Services
{
    public interface ITaskDispatcherService
    {
        public Task<DispatchTaskResponse> DispatchTask(DispatchTaskRequest request);
    }
}
