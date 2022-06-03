using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace andresflorez.hotel.repositorio
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private DbContext ContextDataBase { get; set; }
        public RepositorioBase(DbContext context) => ContextDataBase = context;

        public T FindById(int id) => ContextDataBase.Find<T>(id);
        public IQueryable<T> FindAll() => ContextDataBase.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => ContextDataBase.Set<T>().Where(expression).AsNoTracking();
        public void Create(T Entity)
        {
            ContextDataBase.Set<T>().Add(Entity);
            ContextDataBase.SaveChanges();
        }
        public void Update(T Entity)
        {
            ContextDataBase.Set<T>().Update(Entity);
            ContextDataBase.SaveChanges();
        }
        public void Delete(T Entity)
        {
            ContextDataBase.Set<T>().Remove(Entity);
            ContextDataBase.SaveChanges();
        }        
    }
}
