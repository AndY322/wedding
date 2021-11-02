using DomainModel.Models;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings
{
    public class AlcoholMap : ClassMap<Alcohol>
    {
        public AlcoholMap()
        {
            Id(x => x.AlcoholId);
            Map(x => x.Name);
        }
    }
}