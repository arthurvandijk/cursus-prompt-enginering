using Cursus.Functions.Models;
using System.Collections.Generic;

namespace Cursus.Functions.Services
{
    public interface ITaskService
    {
        List<ToDoTask> GetAllTasks();
        ToDoTask GetTaskById(int id);
        ToDoTask CreateTask(ToDoTask task);
        ToDoTask UpdateTask(int id, ToDoTask task);
        bool DeleteTask(int id);
        List<ToDoTask> GetTasksByStatus(bool isCompleted);
    }

    public class TaskService : ITaskService
    {
        private static List<ToDoTask> _tasks = new List<ToDoTask>();
        private static int _nextId = 1;

        public List<ToDoTask> GetAllTasks()
        {
            return _tasks;
        }

        public ToDoTask GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public ToDoTask CreateTask(ToDoTask task)
        {
            task.Id = _nextId++;
            task.CreatedAt = DateTime.Now;
            _tasks.Add(task);
            return task;
        }

        public ToDoTask UpdateTask(int id, ToDoTask task)
        {
            var existingTask = GetTaskById(id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
                existingTask.AssignedTo = task.AssignedTo;
                existingTask.Priority = task.Priority;
                
                if (task.IsCompleted && existingTask.CompletedAt == null)
                {
                    existingTask.CompletedAt = DateTime.Now;
                }
            }
            return existingTask;
        }

        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }
            return false;
        }

        public List<ToDoTask> GetTasksByStatus(bool isCompleted)
        {
            return _tasks.Where(t => t.IsCompleted == isCompleted).ToList();
        }
    }
}
