using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class CategoryRepository : Repository<Categoria>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public Categoria GetCategoria(int Id)
        {
            return _context.Categorias.FirstOrDefault(c => c.CategoriaId == Id);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            var categorias = _context.Categorias.ToList();
            return categorias;
        }

        public Categoria Create(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public Categoria Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public Categoria Update(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return categoria;
        }

        public IEnumerable<Categoria> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
