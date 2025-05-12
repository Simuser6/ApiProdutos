using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) : base(context)
        { }

        public Produto Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetProduto()
        {
            throw new NotImplementedException();
        }

        public Produto GetProduto(int Id)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Produto> GetProdutosPorCateoria(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Produto> GetProdutosPorCateoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
