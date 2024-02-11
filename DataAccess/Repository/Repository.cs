﻿using CatchMore.DataAccess.Data;
using CatchMore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatchMore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._DbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _DbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _DbSet.RemoveRange(entity);
        }
    }
}