using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.UI.Data
{
    internal static class SavuDBContextMigrators
    {
        internal static void SeedData(SavuDiary.Server.DataLayers.SavuDiaryDBContext context)
        {
            try
            {
                if (context.Database.EnsureCreated())
                {
                    context.Products.AddRange(new Server.DataLayers.ProductEntity[]
                    { new Server.DataLayers.ProductEntity(){ Code="CD233",Description="CD233",Id=Guid.Parse("DA0818D2-BCAB-4F27-97E2-863995E10F86"),IsActive=true,Unit="NUMBERS",Name="TEST" } });
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {

            }
        }
    }
}
