using RabbitMQ.Client;
using RabbitMQ.Consumer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public class ConsumerWithAcknowledge : BaseConsumer
    {
        public override void Consume()
        {
            channel.BasicConsume(queue: "example-messageQueue", autoAck: false, consumer: consumer); // otomatik mesaj silme kapalı 

            consumer.Received += (sender, e) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
                Thread.Sleep(3000); // logic işlemler 
                channel.BasicAck(e.DeliveryTag, multiple: false); // multiple => bu mesajdan daha önce queue'ya eklenen mesajlarıda sil 
                // mesajlar işlendikten sonra bir kontrol dahilinde silme işlemleri yapılandırılır.
            };
        }
    }
}
