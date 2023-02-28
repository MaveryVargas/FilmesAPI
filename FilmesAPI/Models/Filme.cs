using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public string Name { get; set; }
    [Required (ErrorMessage = "O titulo é invalido") ] //Obriga preenchimento
    [MaxLength(50, ErrorMessage = "O filme nao pode ter mais de 50 caracteres")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O genero é invalido")]
    [MaxLength(15,ErrorMessage = "O genero nao pode ter mais de 15 caracteres")] //limita o tamanho dos caracteres
    public string Genero { get; set; }
    [Required]
    [Range(50,700,ErrorMessage = "Minutagem deve ficar entre 50 a 700 minutos")] // limita um intervalo de valores
    public float Duracao { get; set;}
    public int Id { get; set; }
}
