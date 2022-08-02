using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDairy.Server.Application.Interfaces
{
    public interface IStockManagementServices : IDataPersistServices<StockMangement>
        , IFetchServices<StockMangement>
    {
       DataResponses< IEnumerable<StockMangement>> CurrentStockOnDate(DateTime fromDate, Guid? ProductId = null);
    }
}
