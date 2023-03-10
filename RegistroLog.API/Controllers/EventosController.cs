using Loja.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroLog.API.Data.Repository;
using RegistroLog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroLog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : MainController
    {
      private IEventoRepository _eventoRepository;
      private readonly ILogger<EventosController> _logger;

        public EventosController(ILogger<EventosController> logger, IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterProdutos()
        {
            return Ok(await _eventoRepository.ObterTodosEventos());
        }

        [HttpPost("")]
        public async Task<IActionResult> Adicionar(Evento evento)
        {
            _eventoRepository.AdicionarEvento(evento);
            return Ok();
        }


    }
}
