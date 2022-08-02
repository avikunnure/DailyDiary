using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public interface IRepository<T> where T : BaseEntity
    {   
        IEnumerable<T> GetAll();
        Task<T> Insert(T entity);
        Task<T> Delete(T entity);
        Task<T> Update(T entity);
        Task<T> GetById(Guid id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    }
}
