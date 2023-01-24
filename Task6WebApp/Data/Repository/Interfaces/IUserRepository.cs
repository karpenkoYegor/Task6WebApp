using Task6WebApp.Data.Entities;

namespace Task6WebApp.Data.Repository.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    bool IsUserExists(string login);
    User GetByNickName(string login);
    List<User> GetAllUsers();
}