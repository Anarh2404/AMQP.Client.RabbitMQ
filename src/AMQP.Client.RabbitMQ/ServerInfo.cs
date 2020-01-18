﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AMQP.Client.RabbitMQ
{
    public struct ServerInfo
    {
        public readonly int Major;
        public readonly int Minor;
        public readonly Dictionary<string, object> Properties;
        public readonly string Mechanisms;
        public readonly string Locales;
        public ServerInfo(int major,int minor, Dictionary<string, object> props,string mechanisms,string locales)
        {
            Major = major;
            Minor = minor;
            Properties = props;
            Mechanisms = mechanisms;
            Locales = locales;
        }
    }
}
