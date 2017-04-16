﻿using System.Data.Entity;
using System.Linq;
using LibSearch.Core.Intefaces.Repository;
using LibSearch.Core.Model;

namespace LibSearch.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly IDbSet<T> _entities;

        public Repository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _entities;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            Save();
        }
        public T GetByID(long id)
        {
            return _entities.Find(id);
        }
    }
}
