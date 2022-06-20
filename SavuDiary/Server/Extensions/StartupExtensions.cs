using Microsoft.EntityFrameworkCore;
using SavuDiary.Server.DataLayers;

namespace SavuDiary.Server.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddStartupServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SavuDiary.Server.DataLayers.SavuDiaryDBContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("SavuDiaryDB")
                    , x => x.MigrationsAssembly(typeof(StartupExtensions).Assembly.FullName)
                    );
            });
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepository<SaleEntry>), typeof(SaleEntryRepository));
            return services;
        }
    }
}
