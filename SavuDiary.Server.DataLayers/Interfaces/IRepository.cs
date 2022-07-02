using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Server.DataLayers
{
    public interface IRepository<T> where T : BaseEntity
    {   
        IQueryable<T> GetAll();
        Task<T> Insert(T entity);
        Task<T> Delete(T entity);
        Task<T> Update(T entity);
        Task<T> GetById(Guid id);
    }
}
