namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsComplete { get; set; }

        // Foreign keys
        public int? AssignedToUserId { get; set; }
        public int? ProjectId { get; set; }

    }
}