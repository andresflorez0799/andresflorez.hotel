using System;
using System.Linq;
using System.Linq.Expressions;

namespace andresflorez.hotel.repositorio
{
    public interface IRepositorioBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> includes1 = null, Expression<Func<T, object>> includes2 = null);
        IQueryable<T> FindIncludes(Expression<Func<T, object>> includes);
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
