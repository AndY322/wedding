using System.Collections.Generic;
using DomainModel.Models;
using NHibernate;
using Services.Repository.Base;
using Services.Repository.Interfaces;

namespace Services.Repository
{
    public class AlcoholService : Repository<Alcohol>, IAlcoholService
    {
        public AlcoholService(ISession session) : base(session)
        {
        }

        public IList<Alcohol> GetAll()
        {
            return GetQueryOver().List();
        }
    }
}