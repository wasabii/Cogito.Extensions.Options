using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cogito.Extensions.Options
{

    public static class OptionsConfigurationServiceCollectionExtensions
    {

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name)
            where TOptions : class
        {
            return Configure<TOptions>(services, name, o => { });
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            return Configure<TOptions>(services, Microsoft.Extensions.Options.Options.DefaultName, configureBinder);
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddOptions();
            services.AddSingleton<IOptionsChangeTokenSource<TOptions>>(a => new ConfigurationChangeTokenSource<TOptions>(name, a.GetRequiredService<IConfigurationRoot>()));
            return services.AddSingleton<IConfigureOptions<TOptions>>(a => new NamedConfigureFromConfigurationOptions<TOptions>(name, a.GetRequiredService<IConfigurationRoot>(), configureBinder));
        }

    }

}
