using SavuDiary.Shared;
using SavuDiary.UI.Common;

namespace SavuDiary.Client
{
    public static class DataServicesConfigurationExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IDataServices<Supplier>, SupplierServices>();
            services.AddTransient<IDataServices<Sale>, SaleServices>();
            services.AddTransient<IDataServices<Product>, ProductServices>();
            services.AddTransient<IDataServices<Customer>, CustomerServices>();
            services.AddTransient<IDataServices<Purchase>, PurchaseServices>();
            services.AddTransient<IDataServices<TaxRuleModel>, TaxRuleModelServices>();
            services.AddTransient<IDataServices<TaxRecordDetails>, TaxRecordDetailsServices>();
            services.AddTransient<IDataServices<Template>, TemplateServices>();
            services.AddTransient<IStockDataServices, StockMangementServices>();
            services.AddTransient<ISaleDataServices, SaleServices>();
            return services;
        }
    }
}
