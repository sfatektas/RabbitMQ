using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer.Abstract
{
    public abstract class BaseConsumer
    {
        protected ConnectionFactory factory = new ConnectionFactory();
        protected IConnection connection;
        protected IModel channel;
        protected EventingBasicConsumer consumer;
        public BaseConsumer()
        {
            factory.Uri = new("amqps://xamohava:spM7OwkS3NfNFbE9e8K5naFn_UW3fPWq@shrimp.rmq.cloudamqp.com/xamohava");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "example-messageQueue", exclusive: false);
            consumer = new(channel);
        }
        public abstract void Consume();


    }
}
