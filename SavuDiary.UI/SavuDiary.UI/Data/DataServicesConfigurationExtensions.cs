using Microsoft.EntityFrameworkCore;
using SavuDiary.Server.DataLayers;
using SavuDiary.Shared;
using SavuDiary.UI.Data;

namespace SavuDiary.UI
{
    public static class DataServicesConfigurationExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IDataServices<Sale>, SaleServices>();
            services.AddTransient<IDataServices<Product>, ProductServices>();
            services.AddTransient<IDataServices<Customer>, CustomerServices>();
            services.AddDbContext<Server.DataLayers.SavuDiaryDBContext>(options =>
            {
                string dbpath = Path.Combine(FileSystem.AppDataDirectory, "SavuDiaryDB.db3");
                options.UseSqlite($"Filename={dbpath}"
                    , x => x.MigrationsAssembly(typeof(DataServicesConfigurationExtensions).Assembly.FullName));
            });
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepository<SaleEntry>), typeof(SaleEntryRepository));
            var provider = services.BuildServiceProvider();
            var context= provider.GetRequiredService<SavuDiary.Server.DataLayers.SavuDiaryDBContext>();
            SavuDBContextMigrators.SeedData(context);
            return services;
        }
    }
}
