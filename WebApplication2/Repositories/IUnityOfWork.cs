using WebApplication2.Repositories;

namespace WebApplication2.Repositories;
public interface IUnityOfWork
{
   IProdutoRepository ProdutoRepository { get; }
   ICategoriaRepository CategoriaRepository { get; }
   void Commit();
};

