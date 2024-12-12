using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly NotificationContext _context;
    private readonly IRabbitMQService _rabbitMQService;

    public NotificationsController(NotificationContext context, IRabbitMQService rabbitMQService)
    {
        _context = context;
        _rabbitMQService = rabbitMQService;
    }

    [HttpPost]
    public async Task<ActionResult<Notification>> CreateNotification(Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        // Отправляем сообщение в RabbitMQ
        _rabbitMQService.SendMessage($"New Notification: {notification.Message}");

        return CreatedAtAction(nameof(CreateNotification), new { id = notification.NotificationId }, notification);
    }
}