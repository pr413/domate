using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models;
using Microsoft.AspNetCore.Mvc;

public class DiaryController : Controller
{
    private readonly AppDbContext _context;

    public DiaryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Diaries.ToList());
    }

    [HttpPost]
    public IActionResult Create(Diary d)
    {
        d.Date = DateTime.Now;
        _context.Diaries.Add(d);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}