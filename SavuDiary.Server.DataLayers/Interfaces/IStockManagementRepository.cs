using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public interface IStockManagementRepository : IRepository<StockMangementEntity>
    {
        List<StockMangementEntity> CurrentStockOnDate(DateTime fromDate, Guid? ProductId = null);
    }
}
