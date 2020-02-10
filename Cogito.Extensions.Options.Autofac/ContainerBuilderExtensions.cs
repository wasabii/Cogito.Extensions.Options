using System;

using Autofac;

using Cogito.Autofac.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.Extensions.Options.Autofac
{

    public static class ContainerBuilderExtensions
    {

        /// <summary>
        /// Registers a type provided by the <see cref="IConfigurationRoot"/> at the given path.
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string name, Action<IComponentContext, TOptions> configure)
            where TOptions : class, new()
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(name, (c, o) => configure(c.GetRequiredService<IComponentContext>(), o)));
        }

        /// <summary>
        /// Registers a type provided by the <see cref="IConfigurationRoot"/> at the given path.
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, string name, Action<TOptions> configure)
            where TOptions : class, new()
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(name, configure));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, Action<IComponentContext, TOptions> configure)
            where TOptions : class, new()
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>((c, o) => configure(c.GetRequiredService<IComponentContext>(), o)));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, Action<TOptions> configure)
            where TOptions : class, new()
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.Configure<TOptions>(configure));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder PostConfigure<TOptions>(this ContainerBuilder builder, string name, Action<IComponentContext, TOptions> configure)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.PostConfigure<TOptions>(name, (c, o) => configure(c.GetRequiredService<IComponentContext>(), o)));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder PostConfigure<TOptions>(this ContainerBuilder builder, string name, Action<TOptions> configure)
            where TOptions : class
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (configure == null)
                throw new ArgumentNullException(nameof(configure));

            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.PostConfigure<TOptions>(name, configure));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder PostConfigure<TOptions>(this ContainerBuilder builder, Action<IComponentContext, TOptions> configure)
            where TOptions : class
        {
            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.PostConfigure<TOptions>((c, o) => configure(c.GetRequiredService<IComponentContext>(), o)));
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="builder">The <see cref="ContainerBuilder"/> to add the services to.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="ContainerBuilder"/> so that additional calls can be chained.</returns>
        public static ContainerBuilder PostConfigure<TOptions>(this ContainerBuilder builder, Action<TOptions> configure)
            where TOptions : class
        {
            builder.RegisterModule<AssemblyModule>();
            return builder.Populate(s => s.PostConfigure<TOptions>(configure));
        }

    }

}
