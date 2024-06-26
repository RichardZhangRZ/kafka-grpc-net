﻿using System.ComponentModel.DataAnnotations;

namespace task_control_service.Models
{
    public class DispatchTaskRequest
    {
        [Required]
        public string RequesterUserId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
