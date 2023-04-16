using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://yjdwxurs:wN1C__2I3RQBa7YFNIZD8YB7HY2Ddl3w@woodpecker.rmq.cloudamqp.com/yjdwxurs");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.QueueDeclare(queue: "example-queue", exclusive: false);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", false, consumer: consumer);

consumer.Received += (sender, e) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.Read();