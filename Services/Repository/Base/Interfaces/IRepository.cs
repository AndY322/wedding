﻿using NHibernate;

namespace Services.Repository.Base.Interfaces
{
    public interface IRepository<T>
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(T entity);
        void Delete(T entity);

        IQueryOver<T, T> GetQueryOver();
    }
}