using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Send
{
    class Receive
    {
        public static void Main()
        {

            //var server = "199.63.213.99 ";
            //var password = "guest";
            //var username = "guest";
            //var factory = new ConnectionFactory() { HostName = server , UserName=@"GLOBAL\H225456" , Password="@aniH45_bear"};
            //var factory = new ConnectionFactory() { HostName = "IE3BDT3L3D9F2" , Port = 5672 , UserName = @"GLOBAL\H225456", Password = "@aniH45_bear" };

            //var factory = new ConnectionFactory() { HostName = "IE3BDT3L3D9F2" , UserName = "agennt", Password = "agennt"};
            ConnectionFactory factory = new ConnectionFactory();
            //factory.UserName = @"GLOBAL\H225456";
            //factory.Password = "@aniH45_bear";
            //factory.VirtualHost = "/";
            //factory.Protocol = Protocols.DefaultProtocol;
            //factory.HostName = "IE3BDT3L3D9F2";
            //factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            factory.UserName = "agennt";
            factory.Password = "agennt";
            //factory.VirtualHost = "/";
            factory.Protocol = Protocols.DefaultProtocol;
            factory.HostName = "199.63.213.99";
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;
            using (IConnection connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hels",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "hels",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }



}
