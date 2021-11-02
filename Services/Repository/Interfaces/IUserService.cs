using DomainModel.Models;
using Services.Repository.Base.Interfaces;

namespace Services.Repository.Interfaces
{
    public interface IUserService : IRepository<User>
    {
        User GetUserByAccessCode(int accessCode);
    }
}