using Microsoft.AspNetCore.Mvc;
using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models;
using System.Linq;

namespace DoMate_Project_by_Priya.Controllers
{
    public class ReminderController : Controller
    {
        private readonly AppDbContext _context;

        public ReminderController(AppDbContext context)
        {
            _context = context;
        }

        // List dikhane ke liye
        public IActionResult Index()
        {
            var reminders = _context.Reminders.OrderBy(r => r.ReminderTime).ToList();
            return View(reminders);
        }

        // Data Save karne ke liye (Sirf ye EK method rakhein)
        [HttpPost]
        public IActionResult Create(string Title, DateTime ReminderTime, bool EnableAlarm)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                var reminder = new Reminder
                {
                    Title = Title,
                    ReminderTime = ReminderTime,
                    EnableAlarm = EnableAlarm,
                    IsCompleted = false
                };

                _context.Reminders.Add(reminder);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // Delete karne ke liye
        public IActionResult Delete(int id)
        {
            var reminder = _context.Reminders.Find(id);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}