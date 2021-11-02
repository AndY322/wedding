using DomainModel.Models;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.FirstName);
            Map(x => x.Surname);
            Map(x => x.LastName);
            Map(x => x.AccessCode);

            HasMany(x => x.Surveys)
                .KeyColumn("UserId");
        }
    }
}