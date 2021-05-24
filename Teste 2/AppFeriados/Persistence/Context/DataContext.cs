using Microsoft.EntityFrameworkCore;
using AppFeriados.Domain.Models;

namespace AppFeriados.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Feriado> Feriado { get; set; }

        public DbSet<TipoFeriado> TipoFeriado { get; set; }
    }
}