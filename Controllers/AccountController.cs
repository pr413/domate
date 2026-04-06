using DoMate_Project_by_Priya.Data;
using DoMate_Project_by_Priya.Models; // Ensure this is here
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // 
using System.Linq;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    // REGISTER
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        // Notification for successful registration
        TempData["Notification"] = "Registration successful! ✅";
        TempData["Type"] = "success";

        return RedirectToAction("Login");
    }

    // LOGIN (Name + Password)
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string name, string password)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Name == name && x.Password == password);

        if (user != null)
        {
            HttpContext.Session.SetString("user", user.Name);

            // --- PENDING TASKS NOTIFICATION LOGIC ---
            // Yahan hum database se count nikal rahe hain
            int pendingCount = _context.TaskItem.Count(t => !t.IsCompleted && !t.IsDeleted);

            TempData["Notification"] = $"Welcome back, {user.Name}! your {pendingCount} tasks pending . 📋";
            TempData["Type"] = "info";
            // ----------------------------------------

            return RedirectToAction("Index", "Task");
        }

        ViewBag.Error = "Invalid Name or Password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        // Logout notification
        TempData["Notification"] = " successfully logout  👋";
        TempData["Type"] = "success";

        return RedirectToAction("Login");
    }
}