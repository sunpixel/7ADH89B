using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMQService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQService(string hostName, string queueName)
    {
        var factory = new ConnectionFactory() { HostName = hostName };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())

        _channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public void SendMessage(string queueName, string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        
        _channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
    }

    public void ReceiveMessages(string queueName)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };
        
        _channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);
    }

    public void Close()
    {
        _channel.Close();
        _connection.Close();
    }
}