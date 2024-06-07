namespace sync.Api.Configs
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Register IServiceConfig implementation
            services.AddScoped<IServiceConfig, ServiceConfig>();

            // Build a temporary service provider to apply the configurations
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var serviceConfigs = serviceProvider.GetServices<IServiceConfig>();
                foreach (var config in serviceConfigs)
                {
                    config.Configure(services);
                }
            }

            return services;
        }
    }

}

