using Microsoft.EntityFrameworkCore;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFeriados.Persistence.Repositories
{
    public class TipoFeriadoRepository : BaseRepository, ITipoFeriadoRepository
    {
        public TipoFeriadoRepository(DataContext context) : base(context)
        { }

        public async Task<List<TipoFeriado>> ListAsync()
        {
            return await _context.TipoFeriado.AsNoTracking().ToListAsync();
        }

    }
}
