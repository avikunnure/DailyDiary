using SavuDiary.Shared;
namespace SavuDiary.Client
{
    public static class DataServicesConfigurationExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IDataServices<Sale>, SaleServices>();
            services.AddTransient<IDataServices<Product>, ProductServices>();
            services.AddTransient<IDataServices<Customer>, CustomerServices>();
            return services;
        }
    }
}
