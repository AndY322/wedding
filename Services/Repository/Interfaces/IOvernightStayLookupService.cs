using System.Collections.Generic;
using DomainModel.Models;
using Services.Repository.Base.Interfaces;

namespace Services.Repository.Interfaces
{
    public interface IOvernightStayLookupService : IRepository<OvernightStayLookup>
    {
        IList<OvernightStayLookup> GetAll();
    }
}