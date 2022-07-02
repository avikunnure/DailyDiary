using Microsoft.Extensions.DependencyInjection;
using SavuDairy.Server.Application.Implementations;
using SavuDairy.Server.Application.Interfaces;
using SavuDiary.Server.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDairy.Server.Application.DependencyInjections
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerServices,CustomerServices>();
            services.AddTransient<IProductServices,ProductServices>();
            services.AddTransient<IPurchaseServices, PurchaseServices>();
            services.AddTransient<ISaleServices, SaleServices>();
            services.AddTransient<ISupplierServices, SupplierServices>();
            services.AddTransient<IStockManagementServices, StockMangementServices>();
            return services;
        }
    }
}
