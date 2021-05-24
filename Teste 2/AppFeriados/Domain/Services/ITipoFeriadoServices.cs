using System.Collections.Generic;
using System.Threading.Tasks;
using AppFeriados.Domain.Models;

namespace AppFeriados.Domain.Services
{
    public interface ITipoFeriadoServices
    {
        Task<List<TipoFeriado>> ListAsync();

    }
}
