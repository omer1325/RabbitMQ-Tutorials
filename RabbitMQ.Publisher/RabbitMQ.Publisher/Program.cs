using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://yjdwxurs:wN1C__2I3RQBa7YFNIZD8YB7HY2Ddl3w@woodpecker.rmq.cloudamqp.com/yjdwxurs");

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.QueueDeclare(queue: "example-queue", exclusive: false);

//byte[] message = Encoding.UTF8.GetBytes("Merhaba");
//channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);


for (int i = 0; i < 100; i++)
{
    byte[] message = Encoding.UTF8.GetBytes("Merhaba");
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);
}
Console.Read();