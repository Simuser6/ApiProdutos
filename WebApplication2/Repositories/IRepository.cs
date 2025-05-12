using System.Linq.Expressions;

namespace WebApplication2.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T? Get(Expression<Func<T, bool>> predicate);

        T? Create(T entity);

        T? Update(T entity);

        T? Delete(T entity);
        object Delete(int id);
        object GetProdutos();
    }
}
