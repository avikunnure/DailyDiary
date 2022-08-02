using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public interface ISaleRepository : IRepository<SaleEntity>
    {
        SaleEntity GetSale(Guid CustomerId, DateTime date);

        IEnumerable<SaleEntity> SaleByFilters(DateTime fromDate, DateTime toDate,Guid Customerid);
    }
}
