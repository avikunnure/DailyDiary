using SavuDiary.Shared;
using System.Net.Http.Json;
using SavuDiary.Server.DataLayers;

namespace SavuDairy.Server.Application.Interfaces
{
    public interface ITemplateServices
        :IDataPersistServices<Template>
        , IFetchServices<Template>
    {
        DataResponses< IEnumerable<Template>> GetTemplateActiveAsOnDate(Guid productid,Guid customerid,DateTime date);
    }
}
