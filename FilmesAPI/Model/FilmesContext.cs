using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Model
{
    public class FilmesContext : DbContext
    {
        public FilmesContext(DbContextOptions<FilmesContext> options)
                : base(options)
        {
        }

        public DbSet<FilmeItem> FimesItens { get; set; } = null!;
    }
}
