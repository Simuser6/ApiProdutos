using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProduto();

        Produto GetProduto(int Id);

        Produto Create(Produto produto);

        Produto Update(Produto produto);

        Produto Delete(int id);
    }
}