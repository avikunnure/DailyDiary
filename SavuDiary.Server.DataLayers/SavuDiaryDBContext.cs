using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;

namespace SavuDiary.Server.DataLayers
{
    public class SavuDiaryDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }
        public DbSet<PurchaseEntity> Purchase { get; set; }
        public DbSet<SaleDetailEntity> SaleDetails { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<StockMangementEntity> StockMangement { get; set; }
        public DbSet<TaxRulesEntity> TaxRules { get; set; }
        public DbSet<TaxRuleDetailsEntity> TaxRuleDetails { get; set; }
        public DbSet<TaxRecordDetailEntity> TaxRecordDetail { get; set; }
        public DbSet<TemplateEntity> Template { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SavuDiaryDBContext()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SavuDiaryDBContext(DbContextOptions<SavuDiaryDBContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRulesEntity>().HasData(Data.TaxData.TaxRules);
            modelBuilder.Entity<TaxRuleDetailsEntity>().HasData(Data.TaxData.TaxRuleDetails);
            base.OnModelCreating(modelBuilder);
        }
    }
}
