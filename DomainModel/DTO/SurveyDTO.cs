using System.Collections.Generic;
using DomainModel.Models;

namespace DomainModel.DTO
{
    public class SurveyDTO : Survey
    {
        public IList<Alcohol> Alcohols { get; set; }

        public IList<OvernightStayLookup> OvernightStayLookups { get; set; }
    }
}