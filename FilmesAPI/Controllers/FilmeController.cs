using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]//Instaciação de API
[Microsoft.AspNetCore.Mvc.Route("[controller]")] // rota do controlador, usa-se "[controller]" para ser mais facil de fazer a manutenção

public class FilmeController : ControllerBase
{

    private static List<Models.Filme> filmes = new List<Filme>();
    [HttpPost] //post -> postar, adicionar informação
    public void AdicionaFilme([FromBody]Filme filme) //from body e pra explicitar o corpo da requisição.
    {
        filmes.Add(filme);//adiciona filme
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }
    [HttpGet] //Get -> leitura, pegar
    public IEnumerable<Filme> RecuperarFilmes() //enumerador
    {
        return filmes;
    }


}
