using BloodBank.Application.Common.Interfaces.Repositories;
using BloodBank.Domain.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> :IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<T> GetAll(bool withNoTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

           
            if (withNoTracking)
                query = query.AsNoTracking();

            return  query.ToList();

        }

        public   IEnumerable<T> GetAllOrderd(Expression<Func<T, object>> orderBy, string? orderByDirection = "ASC", bool withNoTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

             query = orderByDirection == OrderBy.Ascending?  query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            if (withNoTracking)
                query = query.AsNoTracking();

            return  query.ToList();

        }


        public  T? GetById(int id) => _context.Set<T>().Find(id);


        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>();
        }

        public  T? Find(Expression<Func<T, bool>> predicate) =>
            _context.Set<T>().FirstOrDefault(predicate);



        public T? Find(Expression<Func<T, bool>> predicate,
                Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            if (include is not null)
                query = include(query);

            return query.FirstOrDefault(predicate);
        }


        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            if (orderBy is not null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }


   
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
            Expression<Func<T, object>>? orderBy = null, string? orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            if (include is not null)
                query = include(query);

            query = query.Where(predicate);

            if (orderBy is not null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy); 
            }

            return query.ToList();
        }


        public T Add(T entity)
        {
            _context.Add(entity);
            return entity;
        }


      

        public void Update(T entity) => _context.Update(entity);

       
        public void Remove(T entity) => _context.Remove(entity);

     
       
        public bool IsExists(Expression<Func<T, bool>> predicate) =>
            _context.Set<T>().Any(predicate);

        public int Count() => _context.Set<T>().Count();

        public int Count(Expression<Func<T, bool>> predicate) => _context.Set<T>().Count(predicate);

       
    }
}
