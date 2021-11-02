using System;

namespace DomainModel.Models
{
    public class Alcohol
    {
        public virtual Guid AlcoholId { get; set; }

        public virtual string Name { get; set; }
    }
}