using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Cursus.Functions.Services;
using Cursus.Functions.DTOs;
using Cursus.Functions.Models;
using System.Text.Json;

namespace Cursus.Functions;

public class TaskFunctions
{
    private readonly ILogger<TaskFunctions> _logger;
    private readonly ITaskService _taskService;

    public TaskFunctions(ILogger<TaskFunctions> logger, ITaskService taskService)
    {
        _logger = logger;
        _taskService = taskService;
    }

    [Function("GetTasks")]
    public IActionResult GetAllTasks([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tasks")] HttpRequest req)
    {
        _logger.LogInformation("Getting all tasks");
        
        var tasks = _taskService.GetAllTasks();
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

    [Function("GetTask")]
    public IActionResult GetTaskById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tasks/{id}")] HttpRequest req, int id)
    {
        _logger.LogInformation($"Getting task with ID: {id}");
        
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            return new NotFoundResult();
        }

        var response = new TaskResponse
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt.ToString(),
            CompletedAt = task.CompletedAt?.ToString(),
            AssignedTo = task.AssignedTo,
            Priority = task.Priority.ToString()
        };

        return new OkObjectResult(response);
    }

    [Function("CreateTask")]
    public async Task<IActionResult> CreateTask([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "tasks")] HttpRequest req)
    {
        _logger.LogInformation("Creating new task");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var createRequest = JsonSerializer.Deserialize<CreateTaskRequest>(requestBody);

        var task = new Models.ToDoTask
        {
            Title = createRequest.Title,
            Description = createRequest.Description,
            AssignedTo = createRequest.AssignedTo,
            Priority = (TaskPriority)createRequest.Priority,
            IsCompleted = false
        };

        var createdTask = _taskService.CreateTask(task);
        
        var response = new TaskResponse
        {
            Id = createdTask.Id,
            Title = createdTask.Title,
            Description = createdTask.Description,
            IsCompleted = createdTask.IsCompleted,
            CreatedAt = createdTask.CreatedAt.ToString(),
            AssignedTo = createdTask.AssignedTo,
            Priority = createdTask.Priority.ToString()
        };

        return new CreatedResult($"/api/tasks/{createdTask.Id}", response);
    }
}