using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.SqlServer.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private DbContextTransaction _transaction;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTran()
        {
           if(_transaction!=null)
            {
                throw new Exception("mevcut bir transaction var.");
            }
            _transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
        }

        public void CommitTran()
        {
           if(_transaction==null)
            {
                throw new Exception("mevcut bir transaction yok.");
            }
            _transaction.Commit();
            _transaction.Dispose();
        }

        public void RollBackTran()
        {
            if (_transaction == null)
            {
                throw new Exception("mevcut bir transaction yok.");
            }
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class,IEntity, new()
        {
            return new Repository<TEntity>(_dbContext);
        }

        public void Dispose()
        {
            if (_transaction == null)
            {
                throw new Exception("mevcut bir transaction yok.");
            }
            _transaction.Dispose();
        }
    }
}
