using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationsService.Services
{
    public class RabbitMqService : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly ILogger<RabbitMqService> _logger;
        private readonly string _filePath = "received_messages.txt";

        public RabbitMqService(ILogger<RabbitMqService> logger)
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672"),
                ClientProvidedName = "Rabbit Contracts App"
            };
            _logger = logger;
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                using var connection = _factory.CreateConnection();
                using var channel = connection.CreateModel();

                string queueName = "ContractsQue";

                channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var rabbitMessage = JsonSerializer.Deserialize<RabbitMessage>(message);

                    // Process the message
                    ProcessMessage(rabbitMessage);
                };

                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                // Keep the service running
                while (!stoppingToken.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                }
            }, stoppingToken);
        }

        private void ProcessMessage(RabbitMessage message)
        {
            _logger.LogInformation($"Received message: {message.Title} from SenderID: {message.SenderID}");
            // Processing logic here



            // Store the message in a text file
            var messageText = JsonSerializer.Serialize(message);
            File.AppendAllText(_filePath, messageText + Environment.NewLine);
        }

        public IEnumerable<RabbitMessage> GetStoredMessages()
        {
            if (!File.Exists(_filePath))
            {
                return Enumerable.Empty<RabbitMessage>();
            }

            var messages = File.ReadAllLines(_filePath)
                               .Select(line => JsonSerializer.Deserialize<RabbitMessage>(line))
                               .ToList();

            return messages;
        }
    }
}
