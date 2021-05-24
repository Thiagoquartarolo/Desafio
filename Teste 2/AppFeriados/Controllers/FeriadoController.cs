using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppFeriados.Domain.Models;
using AppFeriados.Domain.Services;

namespace AppFeriados.Controllers
{
    //[Authorize("Bearer")]
    [Route("/v1/[controller]")]
    [ApiController]
    public class FeriadoController : Controller
    {
        private readonly IFeriadoServices _feriadoService;

        public FeriadoController(IFeriadoServices feriadoService)
        {
            _feriadoService = feriadoService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Feriado>>> Get()
        {
            return await _feriadoService.ListAsync();
        }

        [HttpGet]
        [Route("GetByMonthYear/{mes}/{ano}")]
        public async Task<ActionResult<List<Feriado>>> Get(int mes, int ano)
        {
            return await _feriadoService.ListFilterAsync(mes, ano);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Feriado>> Post([FromBody] Feriado model)
        {
            if (ModelState.IsValid)
            {
                return await _feriadoService.AddFeriado(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Feriado>> Put([FromBody] Feriado model)
        {
            if (ModelState.IsValid)
            {
                return await _feriadoService.UpdateFeriado(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{feriadoId:int}")]
        public async Task<ActionResult<Feriado>> Delete(int feriadoId)
        {
            if (ModelState.IsValid)
            {
                return await _feriadoService.DeleteFeriado(feriadoId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}