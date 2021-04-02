using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Publisher
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
                    var body = Encoding.UTF8.GetBytes("Hello RabbitMQ");
                    channel.BasicPublish("", "queue", null, body);//Default Exchange(string empty)
                }
            }
        }
    }
}