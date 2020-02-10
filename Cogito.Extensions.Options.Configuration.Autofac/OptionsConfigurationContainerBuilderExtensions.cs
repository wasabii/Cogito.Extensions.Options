using System;

using Autofac;

using Cogito.Autofac.DependencyInjection;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Options.Configuration.Autofac
{

    public static class OptionsConfigurationContainerBuilderExtensions
    {

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string name, string section, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(name, section, configureBinder));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="optionsType">The type of options being configured.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="section"></param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure(this ContainerBuilder builder, Type optionsType, string name, string section, Action<BinderOptions> configureBinder)
        {
            if (optionsType is null)
                throw new ArgumentNullException(nameof(optionsType));
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure(optionsType, name, section, configureBinder));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="section">The section of the options instance.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string name, string section)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(name, section));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="optionsType">The type of options being configured.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="section">The section of the options instance.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure(this ContainerBuilder builder, Type optionsType, string name, string section)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (optionsType is null)
                throw new ArgumentNullException(nameof(optionsType));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure(optionsType, name, section));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string section, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            if (configureBinder == null)
                throw new ArgumentNullException(nameof(configureBinder));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(section, configureBinder));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="optionsType">The type of options being configured.</param>
        /// <param name="section"></param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure(this ContainerBuilder builder, Type optionsType, string section, Action<BinderOptions> configureBinder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (optionsType is null)
                throw new ArgumentNullException(nameof(optionsType));
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            if (configureBinder == null)
                throw new ArgumentNullException(nameof(configureBinder));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure(optionsType, section, configureBinder));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string section)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(section));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="optionsType">The type of options being configured.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure(this ContainerBuilder builder, Type optionsType, string section)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (optionsType is null)
                throw new ArgumentNullException(nameof(optionsType));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure(optionsType, section));
        }

    }

}
