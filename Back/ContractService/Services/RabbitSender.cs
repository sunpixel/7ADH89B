using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ContractService.Services
{
    public class RabbitMqService
    {
        private readonly ConnectionFactory _factory;

        public RabbitMqService()
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672"),
                ClientProvidedName = "Rabbit Contracts Sender App"
            };
        }

        public void SendMessage(RabbitMessage message)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            string exchangeName = "contracts exchange";
            string routingKey = "contracts-routing";
            string queueName = "ContractsQue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queueName, exchangeName, routingKey, arguments: null);

            var messageBody = JsonSerializer.Serialize(message);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(messageBody);

            channel.BasicPublish(exchangeName, routingKey, basicProperties: null, body: messageBodyBytes);
        }
    }
}
