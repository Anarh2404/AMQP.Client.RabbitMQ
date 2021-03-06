﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AMQP.Client.RabbitMQ.Protocol.Methods.Basic
{
    public struct  DeliverInfo
    {
        public readonly string ConsumerTag;
        public readonly long DeliverTag;
        public readonly bool Redelivered;
        public readonly string ExchangeName;
        public readonly string RoutingKey;
        public DeliverInfo(string consumerTag, long deliverTag, bool redelivered, string exchangeName, string routingKey)
        {
            ConsumerTag = consumerTag;
            DeliverTag = deliverTag;
            Redelivered = redelivered;
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
        }
    }
}
