using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;
        private ILogger<CategoriaController> _logger;
        private ICategoryRepository repository;

        public CategoriaController(ICategoryRepository _repository, ILogger<CategoriaController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias =  _repository.GetAll();    
            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public ActionResult<int> GetPrimaryKey(int id)
        {

            //throw new ArgumentException("Ocorreu um erro");

            var categoria = _repository.Get(c=> c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound();
            }

            return Ok(categoria.Id);
        }


        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            return CreatedAtAction("obtercategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _repository.Update(categoria);

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _repository.Get(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound();
            }

            var categoriaExcluida = _repository.Get(c => c.CategoriaId == id);

            return Ok(categoriaExcluida);
        }
    }
}
