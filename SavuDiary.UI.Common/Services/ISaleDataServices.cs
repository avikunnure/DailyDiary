using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.UI.Common
{
    public interface ISaleDataServices:IDataServices<Sale>
    {
        Task<DataResponses<Sale>> GetSale(Guid CustomerId, DateTime date);

        Task<DataResponses<IEnumerable<Sale>>> SaleByFilters(DateTime fromDate, DateTime toDate, Guid Customerid);
    }
}
