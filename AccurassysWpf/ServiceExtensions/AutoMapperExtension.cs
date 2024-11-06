using AccurassysWpf.Resources.MapProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace AccurassysWpf.ServiceExtensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile));
            
            return services;
        }
    }
}