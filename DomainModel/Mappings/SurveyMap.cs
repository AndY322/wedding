using DomainModel.Models;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings
{
    public class SurveyMap : ClassMap<Survey>
    {
        public SurveyMap()
        {
            Id(x => x.SurveyId);
            Map(x => x.UserId).ReadOnly();
            Map(x => x.WillYouParticipate);
            Map(x => x.AlcoholId);
            Map(x => x.OvernightStayId);
            Map(x => x.Allergies);

            References(x => x.User, "UserId")
                .LazyLoad();
        }
    }
}