using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace YourProjectName.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.TaskItem
                .Where(x => !x.IsDeleted)
                .ToList();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(TaskItem t)
        {
            _context.TaskItem.Add(t);
            _context.SaveChanges();

            // --- NAYA NOTIFICATION ---
            TempData["Notification"] = "New task add  📝";
            TempData["Type"] = "success";

            return RedirectToAction("Index");
        }

        public IActionResult Toggle(int id)
        {
            var t = _context.TaskItem.Find(id);

            if (t != null)
            {
                t.IsCompleted = !t.IsCompleted;
                _context.SaveChanges();

                // --- NAYA NOTIFICATION ---
                string status = t.IsCompleted ? "Completed!! ✅" : "Pending your task!! ⏳";
                TempData["Notification"] = $"Task {status}";
                TempData["Type"] = "info";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var t = _context.TaskItem.Find(id);

            if (t != null)
            {
                t.IsDeleted = true;
                _context.SaveChanges();

                // --- NAYA NOTIFICATION ---
                TempData["Notification"] = "Task deleted! 🗑️";
                TempData["Type"] = "error"; // Red notification for delete
            }

            return RedirectToAction("Index");
        }
    }
}