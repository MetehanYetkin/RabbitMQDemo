﻿using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    public class Send
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Helloo"
                    , durable: false
                    , exclusive: false
                    , autoDelete: false
                    , arguments: null);
                string message = "Hello World ";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                    routingKey: "Helloo",
                    basicProperties: null,
                    body: body);
                Console.WriteLine("[x] Send {0}",message);
                    
            }
            Console.WriteLine("Press [enter] to exit .");
            Console.ReadLine();
        }
    }
}
