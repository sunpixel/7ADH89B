using Microsoft.AspNetCore.Mvc;
using NotificationsService.Services;

namespace NotificationsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly RabbitMqService _rabbitMqService;

        public ProducerController(RabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        // POST api/producer
        [HttpPost]
        public IActionResult SendMessage([FromBody] RabbitMessage message)
        {
            if (message == null)
            {
                return BadRequest("Message data is invalid.");
            }

            _rabbitMqService.SendMessage(message);

            return Ok(new { Message = "Message sent to RabbitMQ" });
        }

        // GET api/producer/messages
        [HttpGet("messages")]
        public IActionResult GetMessages()
        {
            var messages = _rabbitMqService.GetStoredMessages();
            return Ok(messages);
        }
    }
}
