using System;
using System.Collections.Generic;
using System.Linq;

using Autofac;

using Cogito.Autofac;

namespace Cogito.Extensions.Options.ConfigurationExtensions.Autofac
{

    /// <summary>
    /// Provides support for attribute based registration of configuration objects.
    /// </summary>
    class RegisterOptionsHandler : IRegistrationHandler
    {

        public void Register(ContainerBuilder builder, Type type, IEnumerable<IRegistrationRootAttribute> attributes)
        {
            foreach (var attribute in attributes.OfType<RegisterOptionsAttribute>())
                if (attribute.Name != null)
                    builder.Configure(type, attribute.Name, attribute.Section);
                else
                    builder.Configure(type, attribute.Section);
        }

    }

}
