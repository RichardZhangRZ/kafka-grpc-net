using task_control_service.Models;

namespace task_control_service.Services
{
    public class TaskDispatcherService : ITaskDispatcherService
    {
        public DispatchTaskResponse DispatchTask(DispatchTaskRequest request)
        {
            return new DispatchTaskResponse
            {
                Message = "Everything seems to be working",
                Success = true
            };
        }
    }
}
