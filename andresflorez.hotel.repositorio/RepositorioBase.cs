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
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            => ContextDataBase.Set<T>().Where(expression).AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes1 = null, Expression<Func<T, object>> includes2 = null)
        {
            if (includes1 != null && includes2 == null)
                return ContextDataBase
                    .Set<T>().Where(expression)
                    .Include(includes1);
            if (includes1 != null && includes2 != null)
                return ContextDataBase
                    .Set<T>().Where(expression)
                    .Include(includes1)
                    .Include(includes2);
            if (includes1 == null && includes2 != null)
                return ContextDataBase
                    .Set<T>().Where(expression)
                    .Include(includes2);
            return ContextDataBase
                    .Set<T>().Where(expression);
        }

        public IQueryable<T> FindIncludes(Expression<Func<T, object>> includes)
            => ContextDataBase.Set<T>().Include(includes);
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
