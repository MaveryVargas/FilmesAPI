using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore; //chamando o entity

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext //dbcontext depende do entity
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) :base(opts)
        {
             
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
