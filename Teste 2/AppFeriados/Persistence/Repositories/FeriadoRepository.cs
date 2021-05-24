using Microsoft.EntityFrameworkCore;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AppFeriados.Persistence.Repositories
{
    public class FeriadoRepository : BaseRepository, IFeriadoRepository
    {
        public FeriadoRepository(DataContext context) : base(context)
        { }

        public async Task<List<Feriado>> ListAsync()
        {
            return await _context.Feriado.AsNoTracking()
                .Include(x => x.TipoFeriado)
                .OrderBy(x => x.DataFeriado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Feriado>> ListFilterAsync(int mes, int ano)
        {
            return await _context.Feriado.AsNoTracking()
                .Include(x => x.TipoFeriado)
                .Where(x => mes > 0 ? x.DataFeriado.Month.Equals(mes) : !x.DataFeriado.Month.Equals(mes))
                .Where(x => ano > 0 ? x.DataFeriado.Year.Equals(ano) : !x.DataFeriado.Year.Equals(ano))
                .OrderBy(x => x.DataFeriado)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Feriado> AddFeriado(Feriado model)
        {
            _context.Feriado.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Feriado> UpdateFeriado(Feriado model)
        {
            _context.Feriado.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Feriado> DeleteFeriado(int feriadoId)
        {
            Feriado feriado = _context.Feriado.Where(x => x.FeriadoId == feriadoId).FirstOrDefault();

            _context.Feriado.Remove(feriado);
            await _context.SaveChangesAsync();

            return feriado;
        }
    }
}