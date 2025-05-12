using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface ICategoryRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategorias();

        Categoria GetCategoria(int Id);

        Categoria Create(Categoria categoria);

        Categoria Update(Categoria categoria);

        Categoria Delete(int id);
    }
}
