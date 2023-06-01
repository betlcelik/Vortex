using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Spotify.core.abstracts;
using Spotify.core.DbConnection.EntityFramework;

namespace Spotify.core.concretes
{
	public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataBaseConnection _context;

        public Repository(DataBaseConnection context) 
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            var deletedEntity =  _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            Save();
        }

        public void DeleteById(int id)
        {
            _context.Remove(_context.Find<T>(id));
            Save();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().SingleOrDefault(filter);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            var r = _context.Find<T>(id);

            _context.Entry(r).State = EntityState.Detached;
            return r;
        }

        public void Insert(T entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.Update(entity);
            Save();
        }
    }
}

