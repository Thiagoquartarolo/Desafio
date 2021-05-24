using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Services;

namespace AppFeriados.Controllers
{
    [Authorize("Bearer")]
    [Route("/v1/[controller]")]
    [ApiController]
    public class TipoFeriadoController : Controller
    {
        private readonly ITipoFeriadoServices _tipoFeriadoService;

        public TipoFeriadoController(ITipoFeriadoServices tipoFeriadoService)
        {
            _tipoFeriadoService = tipoFeriadoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<TipoFeriado>>> Get()
        {
            return await _tipoFeriadoService.ListAsync();
        }

    }
}