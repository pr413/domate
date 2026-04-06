using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models;
using Microsoft.AspNetCore.Mvc;

public class RoutineController : Controller
{
    private readonly AppDbContext _context;

    public RoutineController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost] 
    public IActionResult Create(string Time, string TaskName)
    {
        if (ModelState.IsValid)
        {
            var routine = new Routine
            {
                Time = Time,
                TaskName = TaskName,
                Status = "Pending"
            };
            _context.Routines.Add(routine);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
    public IActionResult Index()
    {
        return View(_context.Routines.ToList());
    }

    public IActionResult Toggle(int id)
    {
        var r = _context.Routines.Find(id);
        r.IsCompleted = !r.IsCompleted;
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
}