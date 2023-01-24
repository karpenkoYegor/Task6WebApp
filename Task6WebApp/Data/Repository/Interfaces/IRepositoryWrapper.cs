
namespace Task6WebApp.Data.Repository.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
    IMessageRepository Message { get; }
    void Save();
}