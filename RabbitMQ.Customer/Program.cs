// See https://aka.ms/new-console-template for more information

// Bağlantı Oluşturma 

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Consumer;
using System.Text;


var consumer = new DefaultConsumer();
//var consumer = new ConsumerWithAcknowledge();

consumer.Consume();

