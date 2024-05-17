namespace task_control_service.Models
{
    public class DispatchTaskResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public TaskDetailsMessage TaskDetails { get; set; }
    }
}
