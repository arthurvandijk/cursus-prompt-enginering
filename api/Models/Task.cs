using System;

namespace Cursus.Functions.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string AssignedTo { get; set; }
        public TaskPriority Priority { get; set; }
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }
}
