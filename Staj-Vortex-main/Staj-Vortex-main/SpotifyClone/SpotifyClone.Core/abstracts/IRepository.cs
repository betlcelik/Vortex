using System;
using System.Linq.Expressions;

namespace Spotify.core.abstracts
{
	public interface IRepository<T>
	{
        IEnumerable<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
        void Save();
    }
}

