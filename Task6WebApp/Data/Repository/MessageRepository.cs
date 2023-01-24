using Task6WebApp.Data.Entities;
using Task6WebApp.Data.Repository.Interfaces;

namespace Task6WebApp.Data.Repository;

public class MessageRepository : RepositoryBase<Message>, IMessageRepository
{
    public MessageRepository(AppDbContext context) : base(context)
    {
    }
}