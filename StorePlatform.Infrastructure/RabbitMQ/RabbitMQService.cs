using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using StorePlatform.Application.Abstractions.RabbitMQ;

public class RabbitMQService : IRabbitMQService
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQService(IConfiguration configuration)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
            Port = int.Parse(configuration["RabbitMQ:Port"] ?? "5672"),
            UserName = configuration["RabbitMQ:UserName"] ?? "guest",
            Password = configuration["RabbitMQ:Password"] ?? "guest"
        };

        _connection = _connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public async Task<string> SendMessage(string queueName, string message)
    {
        _channel.QueueDeclare(queue: queueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
                              routingKey: queueName,
                              basicProperties: null,
                              body: body);
        return await ValueTask.FromResult("Sended to queue" );
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}