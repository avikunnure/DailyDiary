using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDairy.Server.Application.Interfaces
{
    public interface ISaleServices : IDataPersistServices<Sale>
        , IFetchServices<Sale>
    {
        Task<DataResponses< Sale>> GetSale(Guid CustomerId, DateTime date);

        DataResponses< IEnumerable<Sale>> SaleByFilters(DateTime fromDate, DateTime toDate, Guid Customerid);
    }
}
