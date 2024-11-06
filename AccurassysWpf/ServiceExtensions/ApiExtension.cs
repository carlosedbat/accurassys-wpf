using AccurassysWpf.Helpers.Environment;
using AccurassysWpf.Models.Entities.Environment;

namespace AccurassysWpf.ServiceExtensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Refit;
    using AccurassysWpf.Services.Api.Products.Interface;
    using System.Net.Http;
    using AccurassysWpf.Services.Api.Authentication;

    public static class ApiExtension
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection services) 
        {
            EnvironmentVariablesDTO environmentVariables = EnvironmentMethods.variables;
            
            var baseAddress = new Uri(environmentVariables.BackendApi);

            services.AddSingleton<TokenProvider>();

            services.AddRefitClientWithSsl<IProductsApi>(baseAddress);
            services.AddRefitClientWithSsl<IAuthenticationApi>(baseAddress);

            return services;
        }

        public static IServiceCollection AddRefitClientWithSsl<TInterface>(this IServiceCollection services, Uri baseAddress)
           where TInterface : class
        {
#if DEBUG
            services.AddRefitClient<TInterface>()
                .ConfigureHttpClient(c => c.BaseAddress = baseAddress)
                .AddHttpMessageHandler<AuthenticatedHttpClientHandler>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                });
#else
            services.AddRefitClient<TInterface>()
                            .ConfigureHttpClient(c => c.BaseAddress = baseAddress)
                            .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();
#endif
            return services;
        }
    }
}
