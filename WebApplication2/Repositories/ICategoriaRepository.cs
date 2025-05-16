using WebApplication2.DTOs;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        object Create(CategoriaDTO categoria);
    }
}
