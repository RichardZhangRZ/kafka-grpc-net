using System.ComponentModel.DataAnnotations;

namespace task_control_service.Models
{
    public class TaskDetailsMessage
    {
        public Guid TaskId { get; set; }

        public string RequesterUserId { get; set; }

        public string Message { get; set; }

        public int Duration { get; set; }
    }
}
