// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;

Console.WriteLine("welcome to ticketing service :)");


var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "root",
    Password = "1234",
    VirtualHost = "/"
};
var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare("bookings", durable: true,
    exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    // get my bite[]
    var body = args.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"New ticket processing is initiated for - {message}");

};

channel.BasicConsume("bookings",true,consumer);

Console.ReadKey();
