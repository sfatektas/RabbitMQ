// See https://aka.ms/new-console-template for more information

// Bağlantı Oluşturma 

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Bağlantı Oluşturma 
ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://xamohava:spM7OwkS3NfNFbE9e8K5naFn_UW3fPWq@shrimp.rmq.cloudamqp.com/xamohava");

//Bağlantı Aktifleştirme kanal açma 
using IConnection connection = factory.CreateConnection(); //disposaable bir nesne
using IModel channel = connection.CreateModel();

//Queue Oluşturma
channel.QueueDeclare(queue: "example-messageQueue", exclusive: false);
//exclusive değeri publisher ile aynı yapılandırmada olmalı.

//ilgili channele tanımlı bir event tanımlıyoruz.
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-messageQueue", autoAck: true, consumer);

//Kuyruğa yeni bir mesaj geldiğinde çalışacak olan fonksiyon.
//consumer.Received += (sender, e) =>
//{
//    Console.WriteLine($"{Encoding.UTF8.GetString(e.Body.Span.ToArray())}");
//};

//Bir diğer event kullanımı
consumer.Received += HandleMessage;
void HandleMessage(object sender, BasicDeliverEventArgs e)
{
    Console.WriteLine($"{Encoding.UTF8.GetString(e.Body.Span.ToArray())}");
}
Console.Read();
