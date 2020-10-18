using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cogito.Extensions.Options.Configuration
{

    public static class OptionsConfigurationServiceCollectionExtensions
    {

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="section">The section of the options instance.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name, string section, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            services.AddOptions();
            services.AddSingleton<IOptionsChangeTokenSource<TOptions>>(a => new ConfigurationChangeTokenSource<TOptions>(name, a.GetRequiredService<IConfiguration>()));
            services.AddSingleton<IConfigureOptions<TOptions>>(a => new NamedConfigureFromConfigurationOptions<TOptions>(name, a.GetRequiredService<IConfiguration>().GetSection(section), configureBinder));
            return services;
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="optionsType">Type of the options.</param>
        /// <param name="section">Section of the options instance.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure(this IServiceCollection services, Type optionsType, string name, string section, Action<BinderOptions> configureBinder)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (optionsType is null)
                throw new ArgumentNullException(nameof(optionsType));
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            services.AddOptions();
            services.AddSingleton(typeof(IOptionsChangeTokenSource<>).MakeGenericType(optionsType), a => Activator.CreateInstance(typeof(ConfigurationChangeTokenSource<>).MakeGenericType(optionsType), name, a.GetRequiredService<IConfiguration>()));
            services.AddSingleton(typeof(IConfigureOptions<>).MakeGenericType(optionsType), a => Activator.CreateInstance(typeof(NamedConfigureFromConfigurationOptions<>).MakeGenericType(optionsType), name, a.GetRequiredService<IConfiguration>().GetSection(section), configureBinder));
            return services;
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string name, string section)
            where TOptions : class
        {
            return Configure<TOptions>(services, name, section, o => { });
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="optionsType">Type of the options.</param>
        /// <param name="name">The name of the options instance.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure(this IServiceCollection services, Type optionsType, string name, string section)
        {
            return Configure(services, optionsType, name, section, o => { });
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string section, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            return Configure<TOptions>(services, Microsoft.Extensions.Options.Options.DefaultName, section, configureBinder);
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="optionsType">Type of the options.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure(this IServiceCollection services, Type optionsType, string section, Action<BinderOptions> configureBinder)
        {
            return Configure(services, optionsType, Microsoft.Extensions.Options.Options.DefaultName, section, configureBinder);
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure<TOptions>(this IServiceCollection services, string section)
            where TOptions : class
        {
            return Configure<TOptions>(services, Microsoft.Extensions.Options.Options.DefaultName, section);
        }

        /// <summary>
        /// Registers a configuration instance which TOptions will bind against.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="optionsType">Type of the options.</param>
        /// <param name="configureBinder">Used to configure the <see cref="BinderOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection Configure(this IServiceCollection services, Type optionsType, string section)
        {
            return Configure(services, optionsType, Microsoft.Extensions.Options.Options.DefaultName, section);
        }

    }

}
