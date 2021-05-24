using System.Collections.Generic;
using System.Threading.Tasks;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;
using AppFeriados.Domain.Services;

namespace AppFeriados.Services
{
    public class TipoFeriadoService : ITipoFeriadoServices
    {
        private readonly ITipoFeriadoRepository _tipoFeriadoRepository;

        public TipoFeriadoService(ITipoFeriadoRepository tipoFeriadoRepository)
        {
            _tipoFeriadoRepository = tipoFeriadoRepository;
        }

        public async Task<List<TipoFeriado>> ListAsync()
        {
            return await _tipoFeriadoRepository.ListAsync();
        }
    }
}