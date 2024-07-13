using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomerServices(this IServiceCollection services, bool useFakeService = false)
    {
        if (useFakeService)
        {
            services.AddScoped<ICustomerService, FakeCustomerService>();
        }
        else
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }

        return services;
    }
}
