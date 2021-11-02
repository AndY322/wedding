using System.Collections.Generic;
using DomainModel.Models;
using Services.Repository.Base.Interfaces;

namespace Services.Repository.Interfaces
{
    public interface IAlcoholService : IRepository<Alcohol>
    {
        IList<Alcohol> GetAll();
    }
}