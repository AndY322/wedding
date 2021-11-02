using System.Linq;
using DomainModel.Models;
using NHibernate;
using Services.Repository.Base;
using Services.Repository.Interfaces;

namespace Services.Repository
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(ISession session) : base(session)
        {
        }

        public User GetUserByAccessCode(int accessCode)
        {
            return GetQueryOver().Where(x => x.AccessCode == accessCode)
                .Take(1)
                .List()
                .FirstOrDefault();
        }
    }
}