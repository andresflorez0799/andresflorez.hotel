using System;
using System.Linq;
using System.Linq.Expressions;

namespace andresflorez.hotel.repositorio
{
    public interface IRepositorioBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);        
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
