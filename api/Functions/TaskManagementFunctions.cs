using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Cursus.Functions.Services;
using Cursus.Functions.DTOs;
using System.Text.Json;

namespace Cursus.Functions
{
    public class TaskManagementFunctions
    {
        private readonly ILogger<TaskManagementFunctions> _logger;
        private readonly ITaskService _taskService;

        public TaskManagementFunctions(ILogger<TaskManagementFunctions> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [Function("UpdateTask")]
        public async Task<IActionResult> UpdateTask([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "tasks/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation($"Updating task with ID: {id}");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updateRequest = JsonSerializer.Deserialize<UpdateTaskRequest>(requestBody);

            var existingTask = _taskService.GetTaskById(id);
            if (existingTask == null)
            {
                return new NotFoundResult();
            }

            var updatedTask = new Models.ToDoTask
            {
                Title = updateRequest.Title,
                Description = updateRequest.Description,
                IsCompleted = updateRequest.IsCompleted,
                AssignedTo = updateRequest.AssignedTo,
                Priority = (Models.TaskPriority)updateRequest.Priority
            };

            var result = _taskService.UpdateTask(id, updatedTask);
            
            var response = new TaskResponse
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                CreatedAt = result.CreatedAt.ToString(),
                CompletedAt = result.CompletedAt?.ToString(),
                AssignedTo = result.AssignedTo,
                Priority = result.Priority.ToString()
            };

            return new OkObjectResult(response);
        }

        [Function("DeleteTask")]
        public IActionResult DeleteTask([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "tasks/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation($"Deleting task with ID: {id}");

            var success = _taskService.DeleteTask(id);
            if (!success)
            {
                return new NotFoundResult();
            }

            return new NoContentResult();
        }

        [Function("GetCompletedTasks")]
        public IActionResult GetCompletedTasks([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tasks/completed")] HttpRequest req)
        {
            _logger.LogInformation("Getting completed tasks");

            var tasks = _taskService.GetTasksByStatus(true);
            var response = tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt.ToString(),
                CompletedAt = t.CompletedAt?.ToString(),
                AssignedTo = t.AssignedTo,
                Priority = t.Priority.ToString()
            });

            return new OkObjectResult(response);
        }

        [Function("GetPendingTasks")]
        public IActionResult GetPendingTasks([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tasks/pending")] HttpRequest req)
        {
            _logger.LogInformation("Getting pending tasks");

            var tasks = _taskService.GetTasksByStatus(false);
            var response = tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt.ToString(),
                CompletedAt = t.CompletedAt?.ToString(),
                AssignedTo = t.AssignedTo,
                Priority = t.Priority.ToString()
            });

            return new OkObjectResult(response);
        }
    }
}
