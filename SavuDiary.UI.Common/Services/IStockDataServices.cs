using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.UI.Common
{
    public interface IStockDataServices:IDataServices<StockMangement>
    {
       Task< DataResponses< IEnumerable<StockMangement>>> GetStockMangements(DateTime date,Guid? productid=null);
    }
}
