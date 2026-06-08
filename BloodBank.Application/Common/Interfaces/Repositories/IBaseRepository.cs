using BloodBank.Domain.Consts;
using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Common.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool withNoTracking = true);

        IEnumerable<T> GetAllOrderd(Expression<Func<T, object>> orderBy, string? orderByDirection = "ASC", bool withNoTracking = true);

        IQueryable<T> GetQueryable();

        


        T? GetById(int id) ;

        T? Find(Expression<Func<T, bool>> predicate);


        T? Find(Expression<Func<T, bool>> predicate,
                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
 
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending);

        T Add(T entity);

        void Update(T entity);
       
        void Remove(T entity);

        
        bool IsExists(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

    }
}
