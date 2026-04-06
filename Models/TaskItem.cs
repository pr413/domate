namespace DoMate_Project_by_Priya.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }
        public string Priority { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? ReminderDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}