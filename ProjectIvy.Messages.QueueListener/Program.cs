using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using ProjectIvy.Messages.Models.Trackings;

namespace ProjectIvy.Messages.QueueListener
{
    class Receive
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "do.anticevic.net" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "trackings", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var tracking = JsonConvert.DeserializeObject<Tracking>(message);
                        Console.WriteLine(" [x] Received {0}", tracking.Latitude);
                    };
                    channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}