using Microsoft.EntityFrameworkCore;
using SavuDiary.Server.DataLayers;
using SavuDiary.Shared;
using SavuDiary.UI.Common;
using SavuDiary.UI.Data;

namespace SavuDiary.UI
{
    public static class DataServicesConfigurationExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IDataServices<Sale>, SaleServices>();
            services.AddScoped<IDataServices<Product>, ProductServices>();
            services.AddScoped<IDataServices<Customer>, CustomerServices>();
            services.AddScoped<IDataServices<Purchase>, PurchaseServices>();
            services.AddScoped<IDataServices<Supplier>, SupplierServices>();
            services.AddDbContext<Server.DataLayers.SavuDiaryDBContext>(options =>
            {
                string dbpath = Path.Combine(FileSystem.AppDataDirectory, "SavuDiaryDB.db3");
                options.UseSqlite($"Filename={dbpath}"
                    , x => x.MigrationsAssembly(typeof(DataServicesConfigurationExtensions).Assembly.FullName));
            },ServiceLifetime.Scoped);
           
            var provider = services.BuildServiceProvider();
            var context= provider.GetRequiredService<SavuDiary.Server.DataLayers.SavuDiaryDBContext>();
            SavuDBContextMigrators.SeedData(context);
            return services;
        }
    }
}
