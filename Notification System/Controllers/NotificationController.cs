using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Services.Interfaces;

public class NotificationController : Controller
{
    private readonly NotificationFactory _factory;

    public NotificationController(NotificationFactory factory)
    {
        _factory = factory;
    }

    [HttpGet]
    public IActionResult Send()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Send(string recipient, string title, string message, string notificationType)
    {
        try
        {
            var sender = _factory.Create(notificationType);

            // Push notifications need a device token
            if (notificationType == "Push" && string.IsNullOrWhiteSpace(recipient))
            {
                ViewBag.Error = "Device token is required for push notifications.";
                return View();
            }

            bool result = await sender.SendAsync(recipient, title, message);

            ViewBag.Message = result ? "Notification sent successfully!" : null;
            ViewBag.Error = result ? null : "Failed to send notification.";
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View();
    }
}
