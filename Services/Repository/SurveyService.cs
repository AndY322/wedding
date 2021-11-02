using System;
using System.Linq;
using DomainModel.Models;
using NHibernate;
using Services.Repository.Base;
using Services.Repository.Interfaces;

namespace Services.Repository
{
    public class SurveyService : Repository<Survey>, ISurveyService
    {
        #region Aliases

        private User User;

        #endregion

        private IUserService _userService;

        public SurveyService(ISession session, IUserService userService) : base(session)
        {
            _userService = userService;
        }

        public Survey GetSurveyByAccessCode(int accessCode)
        {
            var user = _userService.GetUserByAccessCode(accessCode);
            if (user == null)
                return null;
            if (!user.Surveys.Any())
            {
                var survey = new Survey()
                {
                    User = user
                };
                Save(survey);
                return survey;
            }

            return GetQueryOver()
                .JoinAlias(x => x.User, () => User)
                .Where(() => User.AccessCode == accessCode)
                .Take(1)
                .List().FirstOrDefault();
        }

        public Survey GetById(Guid surveyId)
        {
            return GetQueryOver().Where(x => x.SurveyId == surveyId).SingleOrDefault();
        }
    }
}