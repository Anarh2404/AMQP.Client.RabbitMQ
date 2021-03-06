﻿using AMQP.Client.RabbitMQ.Protocol.Internal;
using Bedrock.Framework.Protocols;
using System.Buffers;
using System;

namespace AMQP.Client.RabbitMQ.Protocol.Methods.Basic
{
    public class BasicPublishWriter : IMessageWriter<BasicPublishInfo>
    {
        private readonly ushort _channelid;
        public BasicPublishWriter(ushort channelId)
        {
            _channelid = channelId;
        }
        public void WriteMessage(BasicPublishInfo message, IBufferWriter<byte> output)
        {
            ValueWriter writer = new ValueWriter(output);
            var payloadSize = 9 + message.ExchangeName.Length + message.RoutingKey.Length;
            FrameWriter.WriteFrameHeader(Constants.FrameMethod, _channelid, payloadSize, ref writer);
            //var checkpoint = writer.Written;
            FrameWriter.WriteMethodFrame(60, 40, ref writer);
            writer.WriteShortInt(0); //reserved-1
            writer.WriteShortStr(message.ExchangeName);
            writer.WriteShortStr(message.RoutingKey);
            writer.WriteBit(message.Mandatory);
            writer.WriteBit(message.Immediate);
            writer.BitFlush();
            //var size = writer.Written - checkpoint;
            writer.WriteOctet(Constants.FrameEnd);
            writer.Commit();
        }
    }
}
