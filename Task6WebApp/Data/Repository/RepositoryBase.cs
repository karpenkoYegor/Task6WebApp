using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task6WebApp.Data.Repository.Interfaces;

namespace Task6WebApp.Data.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected AppDbContext Context { get; set; }
    public RepositoryBase(AppDbContext context)
    {
        Context = context;
    }
    public T FindBy(Expression<Func<T, bool>> expression) =>
        Context.Set<T>().Where(expression).AsNoTracking().FirstOrDefault();
    public void Create(T entity) => Context.Set<T>().Add(entity);
    public void CreateAll(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
    }

    public void Update(T entity) => Context.Set<T>().Update(entity);

    public void Delete(T entity) => Context.Set<T>().Remove(entity);
}