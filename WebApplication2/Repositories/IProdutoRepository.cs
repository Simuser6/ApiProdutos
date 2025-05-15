using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
}
