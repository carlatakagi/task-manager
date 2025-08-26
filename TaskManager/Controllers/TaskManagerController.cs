using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TaskManagerController : ControllerBase
    {
        private static readonly List<string> Tasks = new()
        {
            "Task 1", "Task 2", "Task 3"
        };

        private readonly ILogger<TaskManagerController> _logger;

        public TaskManagerController(ILogger<TaskManagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<string> Get()
        {
            return Tasks;
        }

        [HttpPost(Name = "AddTask")]
        public IActionResult Add([FromBody] string task)
        {
            if (string.IsNullOrWhiteSpace(task))
            {
                return BadRequest("Task cannot be empty.");
            }

            Tasks.Add(task);
            return Ok();
        }

        [HttpDelete("{taskId}", Name = "DeleteTask")]
        public IActionResult Delete(int taskId)
        {
            if (taskId < 0 || taskId >= Tasks.Count)
            {
                return NotFound("Task not found.");
            }

            Tasks.RemoveAt(taskId);
            return Ok();
        }
    }
}