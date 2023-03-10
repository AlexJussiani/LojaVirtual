using Loja.MessageBus;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Threading;
using Loja.Core.Messages.Integration;
using RegistroLog.API.Data.Repository;
using RegistroLog.API.Models;

namespace RegistroLog.API.Services
{
    public class RegistrarEventoIntegraionHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        private IEventoRepository _eventoRepository;

        public RegistrarEventoIntegraionHandler(
                           IServiceProvider serviceProvider,
                           IMessageBus bus,
                           IEventoRepository eventoRepository)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
            _eventoRepository = eventoRepository;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<AdicionarEventoIntegrationEvent>("EventoRegistrado",
                async request => await RegistrarEvento(request));
        }

        private async Task<ResponseMessage> RegistrarEvento(AdicionarEventoIntegrationEvent IntegrationEvento)
        {
             var msg = mapearEvento(IntegrationEvento);

            _eventoRepository.AdicionarEvento(msg);
            return null;
        }

        private Evento mapearEvento(AdicionarEventoIntegrationEvent IntegrationEvento)
        {
            Evento evento = new Evento(IntegrationEvento.DataAcesso,
                IntegrationEvento.Descricao,
                (AcaoObjeto)IntegrationEvento.AcaoObjeto,
                (TipoObjeto)IntegrationEvento.TipoObjeto,
                IntegrationEvento.IdUsuario,
                IntegrationEvento.NomeUsuario,
                IntegrationEvento.IdObjeto,
                IntegrationEvento.NomeObjeto);
            return evento;
        }
    }
}
