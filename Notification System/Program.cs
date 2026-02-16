using Notification_System.Services;
using NotificationSystem.Data;
using NotificationSystem.Services.Senders;
using NotificationSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// --------------------
// Database
// --------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --------------------
// Required for SmsSender
// --------------------
builder.Services.AddHttpClient();

// --------------------
// Senders (register concrete services)
// --------------------
builder.Services.AddScoped<EmailSender>();
builder.Services.AddScoped<SmsSender>();
builder.Services.AddScoped<PushSender>(); // PushSender must accept IConfiguration in constructor

// --------------------
// Factory (singleton using IServiceProvider)
// --------------------
//builder.Services.AddSingleton<NotificationFactory>();
builder.Services.AddScoped<NotificationFactory>();


// --------------------
// NotificationService
// --------------------
builder.Services.AddScoped<NotificationService>();

// --------------------
// MVC
// --------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Notification}/{action=Send}/{id?}");

app.Run();
