using Microsoft.AspNetCore.Mvc;
using ContractService.Services;
using System.Text.Json;

namespace ContractService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly RabbitMqService _rabbitMqService;

        public ContractController(RabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        // POST api/contract
        [HttpPost]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            if (contract == null)
            {
                return BadRequest("Contract data is invalid.");
            }

            var rabbitMessage = new RabbitMessage
            {
                SenderID = contract.UserID,
                Title = "New Contract Created",
                Message = JsonSerializer.Serialize(contract)
            };

            _rabbitMqService.SendMessage(rabbitMessage);

            return Ok(new { Message = "Contract created and message sent to RabbitMQ" });
        }
    }
}
