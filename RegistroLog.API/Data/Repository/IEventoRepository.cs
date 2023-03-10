using RegistroLog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroLog.API.Data.Repository
{
    public interface IEventoRepository
    {
        Task<List<Evento>> ObterTodosEventos();
        void AdicionarEvento(Evento evento);
    }
}
