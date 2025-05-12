using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IRepository<Produto> _repository;

    public ProdutoController(IRepository<Categoria> repository,
        IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
        _repository = (IRepository<Produto>?)repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var Produtos = _repository.GetAll();
        if (Produtos is null)
        {
            return NotFound();
        }

        return Produtos;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _produtoRepository.Get(c=> c.CategoriaId == id);
        if (produto is null)
        {
            return NotFound();
        }

        return produto;

    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto == null)
            return BadRequest();

        var novoProduto = _repository.Create(produto);

        return CreatedAtAction("obterproduto",
            new { id = produto.Id }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        var produtoAtualizado = _repository.Update(produto);

        return Ok(produtoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _repository.Get(p => p.Id == id);
        if(produto is null)
        {
            return NotFound();
        }
        
        var produtoDeletado = _repository.Delete(produto);  
        return Ok(produto);
    }

}

