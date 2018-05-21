using System;
using CommandDotNet;
using CommandDotNet.Attributes;
using CommandDotNet.IoC.SimpleInjector;
using FluentAssertions;
using SimpleInjector;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        public class IoCTests
        {
            [Fact]
            public void CanAutofacInjectService()
            {
                Container containerBuilder = new Container();
                containerBuilder.Register<IService, Service>();

                AppRunner<ServiceApp> serviceApp = new AppRunner<ServiceApp>().UseSimpleInjector(containerBuilder);

                serviceApp.Run("Process").Should().Be(4);
            }
        }

        public class ServiceApp
        {
            [InjectProperty]
            public IService Service { get; set; }

            public int Process()
            {
                return Service?.value ?? throw new Exception("Service is not injected");
            }
        }

        public interface IService
        {
            int value { get; set; }
        }

        public class Service : IService
        {
            public int value { get; set; } = 4;
        }
    }
}