using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDairy.Server.Application.Interfaces
{

    public interface IFetchServices<T> where T : class ,new()
    {
        Task<DataResponses<IEnumerable<T>>> GetAll();
        Task<DataResponses<T>> Get(Guid guid);
        
    }
    public interface IDataPersistServices<T> where T : class, new()
    {
        Task<DataResponses<T>> Post(T t);
        Task<DataResponses<T>> Put(T t);
        Task<DataResponses<T>> Delete(T t);
    }
}
