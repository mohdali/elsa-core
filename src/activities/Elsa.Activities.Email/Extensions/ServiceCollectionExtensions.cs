using System;
using Elsa;
using Elsa.Activities.Email;
using Elsa.Activities.Email.Options;
using Elsa.Activities.Email.Services;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static ElsaOptionsBuilder AddEmailActivities(this ElsaOptionsBuilder options, Action<SmtpOptions>? configureOptions = null)
        {
            options.Services.AddEmailServices(configureOptions);
            options.AddEmailActivitiesInternal();
            return options;
        }

        public static IServiceCollection AddEmailServices(this IServiceCollection services, Action<SmtpOptions>? configureOptions = null)
        {
            if (configureOptions != null) 
                services.Configure(configureOptions);

            return services.AddSingleton<ISmtpService, SmtpService>();
        }

        private static ElsaOptionsBuilder AddEmailActivitiesInternal(this ElsaOptionsBuilder services) => services.AddActivity<SendEmail>();
    }
}