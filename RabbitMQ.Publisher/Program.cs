// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;
using System.Text;

/* // Publisher işlem sırası ; 
 * Bağlantı oluşturma (RabbitMQ sunucusuna bağlanmak)
 * Bağlantı Aktifleştirme ve Kanal Açma (Bağlandıktan sonra işlemleri yönetebilmek için kanal açmak)
 * Queue Oluşturma
 * Queue'ye Mesaj Gönderme
 * 
 */

//Bağlantı Oluşturm işlemi 
ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new("amqps://xamohava:spM7OwkS3NfNFbE9e8K5naFn_UW3fPWq@shrimp.rmq.cloudamqp.com/xamohava");

//Bağlantıyı Aktşfleştirme ve channel açma 
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue oluşturma 
channel.QueueDeclare("example-messageQueue", exclusive: false); // excluesive sadece bu bağlantıya özel bağlantı sağlar , true olarak atanırsa farklı bir consumerdan kuyruğa erişemeyeceğiz.

//Queue'ye mesajı publish etme 

byte[] message = Encoding.UTF8.GetBytes("First Publish message");

channel.BasicPublish(exchange: "", routingKey: "example-messageQueue", body: message);
Console.WriteLine("message publish edildi.");

//eğer default olarak exchange boş geçilir ise rabbitMQ direct exchange yaklaşımı kabul eder.
//direct exchange yapısında routuing key değeri queue ismine denk gelir.

Console.Read();
