using DomainModel.Models;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings
{
    public class OvernightStayLookupMap : ClassMap<OvernightStayLookup>
    {
        public OvernightStayLookupMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}