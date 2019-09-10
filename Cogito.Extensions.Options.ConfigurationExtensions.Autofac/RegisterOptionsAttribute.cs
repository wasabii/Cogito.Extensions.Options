using System;

using Cogito.Autofac;

namespace Cogito.Extensions.Options.ConfigurationExtensions.Autofac
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterOptionsAttribute :
        Attribute,
        IRegistrationRootAttribute
    {

        readonly string name;
        readonly string section;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="section"></param>
        public RegisterOptionsAttribute(string section) :
            this(null, section)
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="section"></param>
        public RegisterOptionsAttribute(string name, string section)
        {
            this.name = name;
            this.section = section ?? throw new ArgumentNullException(nameof(section));
        }

        /// <summary>
        /// Name of the options instance to register.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Section on which to bind options.
        /// </summary>
        public string Section => section;

        Type IRegistrationRootAttribute.HandlerType => typeof(RegisterOptionsHandler);

    }

}
