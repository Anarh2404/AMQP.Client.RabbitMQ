﻿using AMQP.Client.RabbitMQ.Consumer;
using AMQP.Client.RabbitMQ.Protocol.Methods.Queue;
using AMQP.Client.RabbitMQ.Publisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMQP.Client.RabbitMQ.Channel
{
    public interface IRabbitMQChannel
    {
        public ushort ChannelId { get; }
        public bool IsOpen { get; }
        Task<bool> TryOpenChannelAsync();
        Task<bool> TryCloseChannelAsync(string reason);
        Task<bool> TryCloseChannelAsync(short replyCode, string replyText, short failedClassId, short failedMethodId);
    }
    public interface IRabbitMQDefaultChannel:IRabbitMQChannel
    {
        ValueTask<bool> ExchangeDeclareAsync(string name, string type, bool durable = false, bool autoDelete = false, Dictionary<string, object> arguments = null);
        ValueTask ExchangeDeclareNoWaitAsync(string name, string type, bool durable = false, bool autoDelete = false, Dictionary<string, object> arguments = null);
        ValueTask<bool> ExchangeDeclarePassiveAsync(string name, string type, bool durable = false, bool autoDelete = false, Dictionary<string, object> arguments = null);
        ValueTask<bool> ExchangeDeleteAsync(string name, bool ifUnused = false); //TODO:починить
        ValueTask ExchangeDeleteNoWaitAsync(string name, bool ifUnused = false); //TODO:починить
        ValueTask<QueueDeclareOk> QueueDeclareAsync(string name, bool durable, bool exclusive, bool autoDelete, Dictionary<string, object> arguments);
        ValueTask<QueueDeclareOk> QueueDeclarePassiveAsync(string name);
        ValueTask QueueDeclareNoWaitAsync(string name, bool durable, bool exclusive, bool autoDelete, Dictionary<string, object> arguments);
        ValueTask<QueueDeclareOk> QueueDeclareQuorumAsync(string name);
        ValueTask<bool> QueueBindAsync(string queueName, string exchangeName, string routingKey = "", Dictionary<string, object> arguments = null);
        ValueTask QueueBindNoWaitAsync(string queueName, string exchangeName, string routingKey = "", Dictionary<string, object> arguments = null);
        ValueTask<bool> QueueUnbindAsync(string queueName, string exchangeName, string routingKey = "", Dictionary<string, object> arguments = null);
        ValueTask<int> QueuePurgeAsync(string queueName);
        ValueTask QueuePurgeNoWaitAsync(string queueName);
        ValueTask QueueDeleteNoWaitAsync(string queueName, bool ifUnused = false, bool ifEmpty = false);
        ValueTask<int> QueueDeleteAsync(string queueName, bool ifUnused = false, bool ifEmpty = false);

        ValueTask<RabbitMQChunkedConsumer> CreateChunkedConsumer(string queueName, string consumerTag, bool noLocal = false, bool noAck = false,
                                                                 bool exclusive = false, Dictionary<string, object> arguments = null);
        ValueTask<RabbitMQConsumer> CreateConsumer(string queueName, string consumerTag, bool noLocal = false, bool noAck = false,
                                                   bool exclusive = false, Dictionary<string, object> arguments = null);

        RabbitMQPublisher CreatePublisher();

    }
    
}
