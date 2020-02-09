﻿using AMQP.Client.RabbitMQ.Protocol.ThrowHelpers;
using Bedrock.Framework.Protocols;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace AMQP.Client.RabbitMQ.Protocol.Methods
{
    public class HeartbeatReader : IMessageReader<bool>
    {
        public bool TryParseMessage(in ReadOnlySequence<byte> input, ref SequencePosition consumed, ref SequencePosition examined, out bool message)
        {
            if (input.Length < 8)
            {
                message = false;
                return false;
            }
            var reader = new SequenceReader<byte>(input);
            reader.Advance(8);
            reader.TryRead(out byte endMarker);
            if (endMarker != 206)
            {
                ReaderThrowHelper.ThrowIfEndMarkerMissmatch();
            }
            message = true;
            consumed = reader.Position;
            examined = consumed;
            return true;

        }
    }
}