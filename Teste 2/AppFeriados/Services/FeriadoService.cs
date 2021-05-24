using System.Collections.Generic;
using System.Threading.Tasks;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Repository;
using AppFeriados.Domain.Services;

namespace AppFeriados.Services
{
    public class FeriadoService : IFeriadoServices
    {
        private readonly IFeriadoRepository _feriadoRepository;

        public FeriadoService(IFeriadoRepository feriadoRepository)
        {
            _feriadoRepository = feriadoRepository;
        }

        public async Task<List<Feriado>> ListAsync()
        {
            return await _feriadoRepository.ListAsync();
        }

        public async Task<List<Feriado>> ListFilterAsync(int mes, int ano)
        {
            return await _feriadoRepository.ListFilterAsync(mes, ano);
        }

        public async Task<Feriado> AddFeriado(Feriado model)
        {
            return await _feriadoRepository.AddFeriado(model);
        }

        public async Task<Feriado> UpdateFeriado(Feriado model)
        {
            return await _feriadoRepository.UpdateFeriado(model);
        }

        public async Task<Feriado> DeleteFeriado(int feriadoId)
        {
            return await _feriadoRepository.DeleteFeriado(feriadoId);
        }
    }
}
