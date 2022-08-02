using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SavuDiary.Server.DataLayers
{
    public class StockManagementRepository : BaseRepository<StockMangementEntity>, IStockManagementRepository
    {
        public StockManagementRepository(SavuDiaryDBContext context) : base(context)
        {
        }



        ~StockManagementRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public List<StockMangementEntity> CurrentStockOnDate(DateTime fromDate, Guid? ProductId = null)
        {
            var listgroup = from stock in Context.StockMangement
                            where stock.IsActive == true
                            
                            group stock by new { stock.ProductId, stock.BatchCode }
                            into pstock
                            select new StockMangementEntity
                            {
                                BarCode = pstock.FirstOrDefault().BarCode,
                                BatchCode = pstock.FirstOrDefault().BatchCode,
                                ProductId = pstock.FirstOrDefault().ProductId,
                                Date = pstock.FirstOrDefault().Date,
                                InQuantity = pstock.ToList().Sum(s => s.InQuantity),
                                OutQuantity = pstock.ToList().Sum(s => s.OutQuantity),
                                IsActive = pstock.FirstOrDefault().IsActive,
                                Price = pstock.FirstOrDefault().Price,
                                Rate = pstock.FirstOrDefault().Rate,

                            };


            var list = from stock in listgroup
                       join p in Context.Products on stock.ProductId equals p.Id
                       where p.IsActive == true
                       select new StockMangementEntity
                       {
                           BarCode = stock.BarCode,
                           ProductId = stock.ProductId,
                           BatchCode = stock.BatchCode,
                           Date = stock.Date,
                           Id = stock.Id,
                           InQuantity = stock.InQuantity,
                           IsActive = stock.IsActive,
                           OutQuantity = stock.OutQuantity,
                           Price = stock.Price,
                           ProductName = p.Name,
                           Rate = stock.Rate
                       };
                       
                       
            if(ProductId!=null && ProductId != Guid.Empty)
            {
                list = from s in list
                       where s.ProductId == ProductId
                       select s;
            }

            return list.ToList();

        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
