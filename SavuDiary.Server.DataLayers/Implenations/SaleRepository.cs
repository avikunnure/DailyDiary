using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SavuDiary.Shared;

namespace SavuDiary.Server.DataLayers
{
    public class SaleRepository : BaseRepository<SaleEntity>, ISaleRepository
    {
        public SaleRepository(SavuDiaryDBContext context) : base(context)
        {
        }

        ~SaleRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public SaleEntity GetSale(Guid CustomerId, DateTime date)
        {
            var list = from s in Context.Sales
                       where s.CustomerId == CustomerId
                       where s.IsActive ==true
                       where s.SaleDateTime.Date == date.Date
                       select s;
            var res= list.FirstOrDefault();
            if (res == null)
            {
                return new SaleEntity() { CustomerId=CustomerId,SaleDateTime=date};
            }
            return res;
        }

        public IEnumerable<SaleEntity> SaleByFilters(DateTime fromDate, DateTime toDate, Guid Customerid)
        {
            var list = from s in Context.Sales
                      
                       where s.IsActive == true
                       where s.SaleDateTime.Date <= toDate.Date
                       where s.SaleDateTime.Date >= fromDate.Date
                       select s;
            if (Customerid != Guid.Empty)
            {
                list = from s in list
                       where s.CustomerId == Customerid
                       select s;
            }
            return list;
        }
    }
}
