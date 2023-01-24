using System.Linq.Expressions;

namespace Task6WebApp.Data.Repository.Interfaces;

public interface IRepositoryBase<T>
{
    public T FindBy(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void CreateAll(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
}