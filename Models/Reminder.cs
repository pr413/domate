using System.ComponentModel.DataAnnotations;

namespace DoMate_Project_by_Priya.Models
{
    public class Reminder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date and Time is required")]
        public DateTime ReminderTime { get; set; }

        public bool EnableAlarm { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}