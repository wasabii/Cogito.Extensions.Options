using System.Collections.Generic;

using Autofac;
using Cogito.Autofac;
using Cogito.Extensions.Options.ConfigurationExtensions.Autofac;

using FluentAssertions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Extensions.Options.Tests.ConfigurationExtensions.Autofac
{

    [TestClass]
    public class OptionsConfigurationContainerBuilderExtensionsTests
    {

        class TestOptions
        {

            public string Foo { get; set; }

            public int Bar { get; set; }

        }

        [RegisterOptions("Test")]
        class TestOptions2
        {

            public string Foo { get; set; }

            public int Bar { get; set; }

        }

        [TestMethod]
        public void CanResolveFromContainer()
        {
            var d = new Dictionary<string, string>()
            {
                ["Test:Foo"] = "FooValue",
                ["Test:Bar"] = "123",
            };

            var l = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource()
                {
                    InitialData = d,
                })
                .Build();

            var b = new ContainerBuilder();
            b.RegisterInstance(l);
            b.Configure<TestOptions>("Test");
            var c = b.Build();

            var o = c.Resolve<IOptions<TestOptions>>();
            o.Value.Foo.Should().Be("FooValue");
            o.Value.Bar.Should().Be(123);

            var s = c.Resolve<IOptionsSnapshot<TestOptions>>();
            s.Value.Foo.Should().Be("FooValue");
            s.Value.Bar.Should().Be(123);
        }

        [TestMethod]
        public void CanResolveFromAttributedContainer()
        {
            var d = new Dictionary<string, string>()
            {
                ["Test:Foo"] = "FooValue",
                ["Test:Bar"] = "123",
            };

            var l = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource()
                {
                    InitialData = d,
                })
                .Build();

            var b = new ContainerBuilder();
            b.RegisterInstance(l);
            b.RegisterFromAttributes(typeof(OptionsConfigurationContainerBuilderExtensionsTests).Assembly);
            var c = b.Build();

            var o = c.Resolve<IOptions<TestOptions2>>();
            o.Value.Foo.Should().Be("FooValue");
            o.Value.Bar.Should().Be(123);

            var s = c.Resolve<IOptionsSnapshot<TestOptions2>>();
            s.Value.Foo.Should().Be("FooValue");
            s.Value.Bar.Should().Be(123);
        }

    }

}
