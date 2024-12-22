/*using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ReceiverApp
{
    // JSON struct
    public class Message
    {
        public string SenderID { get; set; }
        public string Title { get; set; }

        [JsonPropertyName("Message")]
        public string MessageContent { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Reciever App";    

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();

            string exchangeName = "demo exchange";
            string routingKey = "demo-routing";
            string queueName = "DemoQue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queueName, exchangeName, routingKey, arguments: null);
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            // Creating a consumer which will decode the message received
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();

                string message = Encoding.UTF8.GetString(body);

                // Deserialize the JSON message
                var deserializedMessage = JsonSerializer.Deserialize<Message>(message);

                Console.WriteLine($"Message received: SenderID={deserializedMessage.SenderID}, Title={deserializedMessage.Title}, Message={deserializedMessage.MessageContent}");

                // must be done last as the message is deleted here or store it SMW or throw an ERROR or SMTH
                channel.BasicAck(args.DeliveryTag, multiple: false);
            };

            string consumerTag = channel.BasicConsume(queueName, autoAck: false, consumer: consumer);

            Console.ReadLine();     // Made to prevent application from stopping ||||||||||| Enter to stop

            channel.BasicCancel(consumerTag);

            channel.Close();
            cnn.Close();
        }
    }
}
*/