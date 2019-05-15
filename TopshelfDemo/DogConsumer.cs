using Common.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopshelfDemo
{
   public class DogConsumer: DefaultBasicConsumer
    {
        static ILog log = LogManager.GetLogger(typeof(DogConsumer));

        public DogConsumer(IModel model)
        {
            base.Model = model;
        }
        public override void HandleBasicCancel(string consumerTag)
        {
            base.HandleBasicCancel(consumerTag);
        }
        public override void HandleBasicCancelOk(string consumerTag)
        {
            base.HandleBasicCancelOk(consumerTag);
        }
        public override void HandleBasicConsumeOk(string consumerTag)
        {
            base.HandleBasicConsumeOk(consumerTag);
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            string msg=   System.Text.Encoding.UTF8.GetString(body);
            log.InfoFormat("收到消息:{0},consumerTag:{1},deliveryTag:{2}",msg,consumerTag,deliveryTag);
            Model.BasicAck(deliveryTag, false);
        }
        public override void HandleModelShutdown(object model, ShutdownEventArgs reason)
        {
            base.HandleModelShutdown(model, reason);
        }
    }
}
