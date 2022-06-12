using Microsoft.EntityFrameworkCore;
namespace SavuDiary.Server.DataLayers
{
    public class SavuDiaryDBContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }
        public DbSet<PurchaseEntity> Purchase { get; set; }
        public DbSet<SaleDetailEntity> SaleDetails { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<StockMangementEntity> StockMangement { get; set; }

        public SavuDiaryDBContext()
        {

        }
        public SavuDiaryDBContext(DbContextOptions<SavuDiaryDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
