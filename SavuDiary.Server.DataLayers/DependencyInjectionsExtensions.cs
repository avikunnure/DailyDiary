using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public static class DependencyInjectionsExtensions
    {
        public static IServiceCollection AddDbReporitory(this IServiceCollection services)
        {
            services.AddTransient<IRepository<CustomerEntity>, CustomerRepository>();
            services.AddTransient<IRepository<ProductEntity>, ProductRepository>();
            services.AddTransient<IRepository<PurchaseDetailEntity>, PurchaseDetailRepository>();
            services.AddTransient<IRepository<PurchaseEntity>, PurchaseRepository>();
            services.AddTransient<IRepository<SaleDetailEntity>, SaleDetailRepository>();
            services.AddTransient<IRepository<SaleEntity>, SaleRepository>();
            services.AddTransient<IRepository<StockMangementEntity>, StockManagementRepository>();
            services.AddTransient<IRepository<SaleEntry>, SaleEntryRepository>();
            services.AddTransient<IRepository<PurchaseEntry>, PurchaseEntryRepository>();
            services.AddTransient<IRepository<SupplierEntity>, SupplierRepository>();
            return services;
        }
    }
}
