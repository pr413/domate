using Microsoft.EntityFrameworkCore;
using DoMate_Project_by_Priya.Models;

namespace DoMate_Project_by_Priya.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Routine> Routines { get; set; }
    }
}