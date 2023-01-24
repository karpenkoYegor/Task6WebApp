using Microsoft.EntityFrameworkCore;
using Task6WebApp.Data.Repository.Interfaces;

namespace Task6WebApp.Data.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private AppDbContext _context;
    private IUserRepository _userRepository;
    private IMessageRepository _messageRepository;

    public RepositoryWrapper(AppDbContext context)
    {
        _context = context;
    }

    public IUserRepository User
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_context);
            return _userRepository;
        }
    }

    public IMessageRepository Message
    {
        get
        {
            if (_messageRepository == null)
                _messageRepository = new MessageRepository(_context);
            return _messageRepository;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}