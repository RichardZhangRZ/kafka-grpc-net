using System.ComponentModel.DataAnnotations;

namespace task_control_service.Models
{
    public class DispatchTaskRequest
    {
        [Required]
        public String RequesterUserId { get; set; }

        [Required]
        public int Message { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
