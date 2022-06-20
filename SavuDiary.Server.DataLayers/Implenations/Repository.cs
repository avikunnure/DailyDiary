using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace SavuDiary.Server.DataLayers
{
    public class Repository<T> : IRepository<T> where T : BaseEntity,new()
    {
        private SavuDiaryDBContext Context { get; }
        public Repository(SavuDiaryDBContext context)
        {
            Context = context;
        }

        public async Task<T> Insert(T entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();
            }
            return entity;
        }
        public async Task<T> Delete(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                entity.IsActive = false;
                Context.Update(entity);
                await Context.SaveChangesAsync();
            }
            return  entity;    
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult( Context.Set<T>().AsNoTracking().AsEnumerable());
        }

        public Task<T> GetById(Guid id)
        {
            var res= Context.Set<T>().Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (res != null)
            {
                return Task.FromResult(res);
                
            }
           return Task.FromResult(new T());
        }
    }
}
