﻿using System.Collections.Generic;

namespace AMQP.Client.RabbitMQ.Protocol.Methods.Connection
{
    public struct RabbitMQClientInfo
    {
        public Dictionary<string, object> Properties;
        public readonly string Mechanism;
        public readonly string Locale;
        public RabbitMQClientInfo(Dictionary<string, object> properties, string mechanism, string locale)
        {
            Properties = properties;
            Mechanism = mechanism;
            Locale = locale;
        }   
        public static RabbitMQClientInfo DefaultClientInfo()
        {
            Dictionary<string, object> props = new Dictionary<string, object>{
                { "product", "AMQP.Client.RabbitMQ" },
                { "version", "0.0.1" },
                { "platform", ".Net" },
                { "copyright", "" },
                { "information","" },                
                { "capabilities", new Dictionary<string,object>
                                    {
                                        { "publisher_confirms", true},
                                        { "exchange_exchange_bindings", true},
                                        { "basic.nack", true},
                                        { "consumer_cancel_notify", true},
                                        { "connection.blocked", true},
                                        { "authentication_failure_close", true},

                                    } 
                },
                { "connection_name","" },
            };
            return new RabbitMQClientInfo(props, "PLAIN","en_US") ;
        }
    }
}
