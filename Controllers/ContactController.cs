using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DoMate_Project_by_Priya.Models;

public class ContactController : Controller
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context)
    {
        _context = context;
    }

    // 📋 Show All Contacts
    public IActionResult Index()
    {
        var data = _context.Contacts.ToList();
        return View(data);
    }

    // ➕ Add Contact
    [HttpPost]
    public IActionResult Create(Contact c)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(c);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    // ❌ Delete Contact
    public IActionResult Delete(int id)
    {
        var contact = _context.Contacts.Find(id);

        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}