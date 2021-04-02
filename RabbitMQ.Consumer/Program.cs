using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("")
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("queue", false, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume("queue", true, consumer);
                    consumer.Received += (model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine($"Message: {message}");
                    };
                }
            }
            Console.ReadLine();
        }
    }
}