using DoMate_Project_by_Priya.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔷 Add Services
builder.Services.AddControllersWithViews();

// 🔷 Database (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔷 Session Enable
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🔷 Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ❗ (Optional) Render pe HTTPS off kar sakte ho
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

// 🔷 Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

// 🔥 DATABASE MIGRATION (CORRECT PLACE)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// 🔥 Render port fix
app.Run("http://0.0.0.0:10000");