using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDairy.Server.Application.Interfaces
{
    public interface ICustomerServices
        :IDataPersistServices<Customer>
        , IFetchServices<Customer>
    {
    }
}
