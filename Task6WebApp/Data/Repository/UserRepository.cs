using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task6WebApp.Data.Entities;
using Task6WebApp.Data.Repository.Interfaces;

namespace Task6WebApp.Data.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public bool IsUserExists(string login)
    {
        var user = Context.Users.FirstOrDefault(u => u.UserName == login);
        return user == null;
    }

    public User GetByNickName(string login)
    {
        return Context.Users.Include(u => u.Messages).FirstOrDefault(u => u.UserName == login);
    }

    public List<User> GetAllUsers()
    {
        return Context.Users.OrderBy(u => u.Name).ToList();
    }
}