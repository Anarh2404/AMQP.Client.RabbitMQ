﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AMQP.Client.RabbitMQ
{
    public class RabbitMQConnectionBuilder
    {
        public RabbitMQConnectionInfo ConnInfo;
        public RabbitMQClientInfo ClientInfo;
        public RabbitMQInfo Info;
        public IPEndPoint Endpoint;
        public RabbitMQConnectionBuilder(IPEndPoint endpoint)
        {
            ConnInfo = RabbitMQConnectionInfo.DefaultConnectionInfo();
            ClientInfo = RabbitMQClientInfo.DefaultClientInfo();
            Info = RabbitMQInfo.DefaultConnectionInfo();
            Endpoint = endpoint;
        }
        public RabbitMQConnectionBuilder ConnectionInfo(string user, string password, string host)
        {
            ConnInfo = new RabbitMQConnectionInfo(user, password, host);
            return this;
        }
        public RabbitMQConnectionBuilder ChanellMax(short chanellMax)
        {
            Info.ChanellMax = chanellMax;
            return this;
        }
        public RabbitMQConnectionBuilder FrameMax(int frameMax)
        {
            Info.FrameMax = frameMax;
            return this;
        }
        public RabbitMQConnectionBuilder Heartbeat(short heartbeat)
        {
            Info.Heartbeat = heartbeat;
            return this;
        }
        public RabbitMQConnectionBuilder ConnectionName(string name)
        {
            ClientInfo.Properties["connection_name"] = name;
            return this;
        }
        public RabbitMQConnectionBuilder ProductName(string name)
        {
            ClientInfo.Properties["product"] = name;
            return this;
        }
        public RabbitMQConnectionBuilder ProductVersion(string version)
        {
            ClientInfo.Properties["version"] = version;
            return this;
        }
        public RabbitMQConnectionBuilder ClientInformation(string name)
        {
            ClientInfo.Properties["information"] = name;
            return this;
        }
        public RabbitMQConnectionBuilder ClientCopyright(string copyright)
        {
            ClientInfo.Properties["copyright"] = copyright;
            return this;
        }
        public RabbitMQConnection Build()
        {
            return new RabbitMQConnection(this);
        }
    }
}
