using System;
using System.ComponentModel;

namespace DomainModel.Models
{
    public class Survey
    {
        public virtual Guid SurveyId { get; set; }

        public virtual Guid UserId { get; set; }
        
        public virtual User User { get; set; }

        [DisplayName("Подтверждение присутствия")]
        public virtual bool? WillYouParticipate { get; set; }

        [DisplayName("Предпочтения по алкоголю")]
        public virtual Guid? AlcoholId { get; set; }
        
        [DisplayName("Планируете ли вы остаться на ночь и разместиться в усадьбе?")]
        public virtual Guid? OvernightStayId { get; set; }
        
        [DisplayName("Есть ли у вас аллергии на продукты?")]
        public virtual string Allergies { get; set; }
    }
}