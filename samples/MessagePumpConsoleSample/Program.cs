﻿using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using MooseSoft.Azure.ServiceBus;
using MooseSoft.Azure.ServiceBus.BackOffDelayStrategy;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MessagePumpConsoleSample
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main()
        {
            //Replace connection string with a valid one
            var connection = new ServiceBusConnection("Endpoint=sb://somesbns.servicebus.windows.net/;SharedAccessKeyName=some-key;SharedAccessKey=fjsdjfkjsdakfjaskfjdskljfkdlsaf=");
            //Replace entity path with path to real entity on your ServiceBus namespace
            var receiver = new MessageReceiver(connection, "test");

            receiver.ConfigureMessagePump()
                .WithMessageProcessor(new SampleMessageProcessor())
                .WithDeferFailurePolicy(e => e is InvalidOperationException)
                .WithBackOffDelayStrategy(ExponentialBackOffDelayStrategy.Default)
                .BuildMessagePump(ExceptionReceivedHandler);

    		Console.WriteLine("Press any key to terminate!");
            Console.Read();
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            //Handle any exception that might bubble up from the message pump however this shouldn't really happen 
            return Task.CompletedTask;
        }
    }
}
