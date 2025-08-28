// Controllers/TaskController.cs
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(TaskModel newTask)
        {
            _taskService.CreateTask(newTask);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TaskModel updatedTask)
        {
            var updated = _taskService.UpdateTask(id, updatedTask);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var removido = _taskService.Delete(id);
            if (!removido) return NotFound();
            return NoContent();
        }
    }
}
