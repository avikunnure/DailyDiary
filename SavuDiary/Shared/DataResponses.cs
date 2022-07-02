using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Shared
{
    public class DataResponses<T> where T : class
    {
        public T? Result { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string Message { get; set; } = "";

        public DataResponses(bool isSuccessStatusCode=false) : this("", isSuccessStatusCode) { }

        public DataResponses(T result, bool isSuccessStatusCode = true)
        {
            Result = result;
            IsSuccessStatusCode=isSuccessStatusCode;
        }
        public DataResponses(string message, bool isSuccessStatusCode = false)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            Message = message;
        }
    }
    public class DataParams
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsQueryString { get; set; } = false;
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
