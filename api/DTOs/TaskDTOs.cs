namespace Cursus.Functions.DTOs
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public int Priority { get; set; }
    }

    public class UpdateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedTo { get; set; }
        public int Priority { get; set; }
    }

    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string CreatedAt { get; set; }
        public string CompletedAt { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; }
    }
}
