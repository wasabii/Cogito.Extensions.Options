using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cogito.Extensions.Options
{

    public static class OptionsServiceCollectionExtensions
    {

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name, Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddOptions();
            services.AddSingleton(p => (IConfigureOptions<TOptions>)new ConfigureNamedOptions<TOptions>(name, o => configure(p, o)));
            return services;
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configure">Used to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            return Configure<TOptions>(services, Microsoft.Extensions.Options.Options.DefaultName, configure);
        }

    }

}
