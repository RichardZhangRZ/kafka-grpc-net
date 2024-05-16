using task_control_service.Models;

namespace task_control_service.Services
{
    public interface ITaskDispatcherService
    {
        public DispatchTaskResponse DispatchTask(DispatchTaskRequest request);
    }
}
