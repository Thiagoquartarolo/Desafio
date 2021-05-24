using AppFeriados.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFeriados.Domain.Repository
{
    public interface ITipoFeriadoRepository
    {
        Task<List<TipoFeriado>> ListAsync();

    }
}
