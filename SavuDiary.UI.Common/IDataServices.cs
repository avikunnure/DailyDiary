using SavuDiary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.UI.Common
{
    public interface IDataServices<T> where T : class
    {
        public Task<DataResponses<IEnumerable<T>>> GetAll(params DataParams[] objects);
        public Task<DataResponses<T>> Get(params DataParams[] obj);
       
        public Task<DataResponses<T>> Post(T t);
        public Task<DataResponses<T>> Put(T t,params DataParams[] dataParams);
        public Task<DataResponses<T>> Delete(T t);
    }
   
}
