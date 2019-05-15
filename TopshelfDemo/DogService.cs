using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Util;
namespace TopshelfDemo
{
    public class DogService
    {
        static ConnectionFactory factory = new ConnectionFactory() { HostName = "10.2.211.26", VirtualHost = "/", UserName = "liufei", Password = "liufei", Port = 5671, AutomaticRecoveryEnabled = true };
        static IConnection connection = factory.CreateConnection();
        static IModel channel = null;
        public void Start()
        {
         
            channel = connection.CreateModel();
            channel.BasicQos(0, 1, true);
            DogConsumer dogConsumner = new DogConsumer(channel);
            channel.BasicConsume("cat", false, dogConsumner);
        }
        public void Stop()
        {
            if (channel.IsOpen)
            {
                channel.Close();
            }
            if(connection.IsOpen)
            {
                connection.Close();
            }

        }
    }
}
