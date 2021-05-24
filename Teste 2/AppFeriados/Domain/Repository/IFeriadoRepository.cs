using System.Collections.Generic;
using System.Threading.Tasks;
using AppFeriados.Domain.Models;

namespace AppFeriados.Domain.Repository
{
    public interface IFeriadoRepository
    {
        Task<List<Feriado>> ListAsync();

        Task<List<Feriado>> ListFilterAsync(int mes, int ano);

        Task<Feriado> AddFeriado(Feriado model);

        Task<Feriado> UpdateFeriado(Feriado model);

        Task<Feriado> DeleteFeriado(int feriadoId);
    }
}
