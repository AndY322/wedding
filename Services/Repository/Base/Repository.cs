using NHibernate;
using Services.Repository.Base.Interfaces;

namespace Services.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        protected Repository(ISession session)
        {
            _session = session;
        }
        
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Save(T entity)
        {
            _session.Save(entity);
            _session.Flush();
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public virtual IQueryOver<T, T> GetQueryOver() => _session.QueryOver<T>();
    }
}