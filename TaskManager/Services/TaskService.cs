using TaskManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<TaskModel> _tasks = new();

        public List<TaskModel> GetAllTasks() => _tasks;

        public TaskModel GetTaskById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void CreateTask(TaskModel task) => _tasks.Add(task);

        public bool UpdateTask(Guid id, TaskModel updatedTask)
        {
            var task = GetTaskById(id);
            if (task == null) return false;

            task.Name = updatedTask.Name;
            task.Description = updatedTask.Description;
            task.Priority = updatedTask.Priority;
            task.LimitDate = updatedTask.LimitDate;
            task.Status = updatedTask.Status;

            return true;
        }

        public bool Delete(Guid id)
        {
            var task = GetTaskById(id);
            if (task == null) return false;

            _tasks.Remove(task);
            return true;
        }
    }
}
