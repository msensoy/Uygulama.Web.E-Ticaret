
using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.SqlServer.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        DbContext _dbContext;
        DbSet<TEntity> _dbset;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
            _dbset.Add(entity);
            return _dbContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw new Exception("expression parametresi null olamaz.");
            }
            return _dbset.Where(expression).SingleOrDefault();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? _dbset.ToList() :
                _dbset.Where(expression).ToList();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbset.Select(t => t);
        }

        public int HardDelete(TEntity entity)
        {
            _dbset.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public int SoftDelete(TEntity entity)
        {
            entity.IsDelete = true;
            return _dbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
