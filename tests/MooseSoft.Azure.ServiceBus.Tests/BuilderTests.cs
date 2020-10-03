﻿using FluentAssertions;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooseSoft.Azure.ServiceBus.Builders;
using NSubstitute;
using System.Diagnostics.CodeAnalysis;

namespace MooseSoft.Azure.ServiceBus.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void MessageContextProcessor_Configure_Test()
        {
            //Act
            var result = Builder.MessageContextProcessor.Configure();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<MessageContextProcessorBuilder>();
        }

        [TestMethod]
        public void MessagePump_Configure_Test()
        {
            //Act
            var result = Builder.MessagePump.Configure(Substitute.For<IMessageReceiver>());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<MessagePumpBuilder>();
        }
    }
}