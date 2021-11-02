using System;
using DomainModel.Models;
using Services.Repository.Base.Interfaces;

namespace Services.Repository.Interfaces
{
    public interface ISurveyService : IRepository<Survey>
    {
        Survey GetSurveyByAccessCode(int accessCode);

        Survey GetById(Guid surveyId);
    }
}