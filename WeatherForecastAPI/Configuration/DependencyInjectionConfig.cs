using WeatherForecastAPI.Services;

namespace WeatherForecastAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<AutenticacaoService, AutenticacaoService>();
        }
    }
}
