using WebApplication2.Models;
using WebApplication2.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.DTOs.Mappings;

namespace WebApplication2.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly IUnityOfWork _uof;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(IUnityOfWork uof,
        ILogger<CategoriasController> logger)
    {

        _logger = logger;
        _uof = uof;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoriaDTO>> Get()
    {
        var categorias = _uof.CategoriaRepository.GetAll();

        if (categorias == null)
            return NotFound("Não existem categorias...");

        // var categoriasDto = new List<CategoriaDTO>();
        //foreach(var categoria in categorias)
        //{
        //    var categoriaDto = new CategoriaDTO()
        //    {
        //        CategoriaId = categoria.CategoriaId,
        //        Nome = categoria.Nome,
        //        ImagemUrl = categoria.ImagemUrl
        //    };
        //    categoriasDto.Add(categoriaDto);
        //}

        var categoriasDto = categorias.ToCategoriaDTOList();
        return Ok(categoriasDto);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<CategoriaDTO> Get(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
        {
            _logger.LogWarning($"Categoria com id= {id} não encontrada...");
            return NotFound($"Categoria com id= {id} não encontrada...");
        }

        var categoriasDto = categoria.ToCategoriaDTO();
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        var categoriasDto = categoriaDto.ToCategoria();
        var categoriaCriada = _uof.CategoriaRepository.Create(categoriaDto);
        _uof.Commit();

        return Ok(categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        var categoriaExistente = _uof.CategoriaRepository.Get(c => c.CategoriaId == id); 
        categoriaExistente.Nome = categoriaDto.Nome;
        categoriaExistente.ImagemUrl = categoriaDto.ImagemUrl;

        _uof.CategoriaRepository.Update(categoriaExistente);
        _uof.Commit();

        var categoriaAtualziadaDto = new CategoriaDTO()
        {
            CategoriaId = categoriaExistente.CategoriaId,
            Nome = categoriaExistente.Nome,
            ImagemUrl = categoriaExistente.ImagemUrl
        };

        var categoriaAtualziada = _uof.CategoriaRepository.Update(categoriaDto);
        return Ok(categoriaAtualziada);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
        {
            _logger.LogWarning($"Categoria com id={id} não encontrada...");
            return NotFound($"Categoria com id={id} não encontrada...");
        }

        var categoriaExcluida = _uof.CategoriaRepository.Delete(categoria);
        _uof.Commit();

        var categoriaDeletadaDto = new CategoriaDTO()
        {
            CategoriaId = categoriaExcluida.CategoriaId,
            Nome = categoriaExcluida.Nome,
            ImagemUrl = categoriaExcluida.ImagemUrl
        };

        return Ok(categoriaExcluida);

    }
}