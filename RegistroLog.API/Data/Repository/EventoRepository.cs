using MongoDB.Bson;
using MongoDB.Driver;
using RegistroLog.API.Data.Configurations;
using RegistroLog.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroLog.API.Data.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IMongoCollection<Evento> _eventosCollection;

        public EventoRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _eventosCollection = database.GetCollection<Evento>("eventos");
        }

        public void AdicionarEvento(Evento evento)
        {
            _eventosCollection.InsertOne(evento);
        }

        public async Task<List<Evento>> ObterTodosEventos()
        {
            return await _eventosCollection.Find(e => true).ToListAsync();
        }
    }
}
