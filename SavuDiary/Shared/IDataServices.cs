using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Shared
{
    public interface IDataServices<T> where T : class
    {
        public Task<IEnumerable<T>?> GetAll(params DataParams[] objects);
        public Task<T?> Get(params DataParams[] obj); 
        public Task<DataResponses> Post(T t);
        public Task<DataResponses> Put(T t,params DataParams[] dataParams);
        public Task<DataResponses> Delete(T t);
    }
    public class DataResponses
    {
        public object? Result { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public DataResponses(object result, bool isSuccessStatusCode)
        {
            Result = result;
            IsSuccessStatusCode = isSuccessStatusCode;
        }
    }
    public class DataParams 
    { 
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsQueryString { get; set; }=false;
        public DataParams(string name, object value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            IsQueryString = false;
        }
        public DataParams(string name, object value, bool isQueryString) : this(name, value)
        {
            IsQueryString = isQueryString;
        }
    }
}
