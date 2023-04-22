using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Consumer.Abstract;

namespace RabbitMQ.Consumer
{
    public class DefaultConsumer : BaseConsumer
    {
        public override void Consume()
        {
            channel.BasicConsume(queue: "example-messageQueue", autoAck: true, consumer: consumer); // Mesajlar otomatik silinir.
            consumer.Received += (sender, e) =>
            {
                Console.WriteLine($"{Encoding.UTF8.GetString(e.Body.Span.ToArray())}");
                Thread.Sleep(2000);
            };
            Console.Read();
        }
    }
}
