using DoMate_Project_by_Priya.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var total = _context.TaskItem.Count(x => !x.IsDeleted);
        var completed = _context.TaskItem.Count(x => x.IsCompleted);
        var pending = _context.TaskItem.Count(x => !x.IsCompleted);

        ViewBag.Total = total;
        ViewBag.Completed = completed;
        ViewBag.Pending = pending;

        return View();
    }
}