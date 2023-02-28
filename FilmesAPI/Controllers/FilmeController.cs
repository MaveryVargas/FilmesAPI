using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]//Instaciação de API
[Microsoft.AspNetCore.Mvc.Route("[controller]")] // rota do controlador, usa-se "[controller]" para ser mais facil de fazer a manutenção

public class FilmeController : ControllerBase
{
    private FilmeContext _context;

    public FilmeController(FilmeContext context)
    {
        _context = context;
    }

    public int Id { get;  set; }

    [HttpPost] //post -> postar, adicionar informação
    public IActionResult AdicionaFilme([FromBody]Filme filme) //from body e pra explicitar o corpo da requisição.  IActionResult muda ações na api (404 not found, 201 created etc...)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme);
        
    }

    [HttpGet] //Get -> leitura, pegar
    public IEnumerable<Filme> RecuperarFilmes([FromQuery] int skip =0,[FromQuery] int take = 50) //enumerador
    {
        return _context.Filmes.Skip(skip).Take(take); //skip pula, take pega
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) // '?' pode ser nulo ou não
    {
        var filme = _context.Filmes.FirstOrDefault(Filme => Filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
