using Microsoft.AspNetCore.Mvc;
using task_control_service.Models;
using task_control_service.Services;

namespace task_control_service.Controllers
{
    [ApiController]
    [Route("api/task-dispatcher")]
    public class TaskRequestController : ControllerBase
    {
        private readonly ILogger<TaskRequestController> _logger;
        private readonly ITaskDispatcherService _taskDispatcherService;

        public TaskRequestController(ILogger<TaskRequestController> logger, ITaskDispatcherService taskDispatcherService)
        {
            _logger = logger;
            _taskDispatcherService = taskDispatcherService;
        }

        [HttpGet("dispatch-task", Name = "Dispatch Task")]
        public ActionResult<DispatchTaskResponse> DispatchTask([FromQuery] DispatchTaskRequest dispatchRequest)
        {
            var response = _taskDispatcherService.DispatchTask(dispatchRequest);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}