using System.Collections.Generic;
using DomainModel.Models;
using NHibernate;
using Services.Repository.Base;
using Services.Repository.Interfaces;

namespace Services.Repository
{
    public class OvernightStayLookupService : Repository<OvernightStayLookup>, IOvernightStayLookupService
    {
        public OvernightStayLookupService(ISession session) : base(session)
        {
        }

        public IList<OvernightStayLookup> GetAll()
        {
            return GetQueryOver().List();
        }
    }
}