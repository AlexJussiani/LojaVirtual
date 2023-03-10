using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RegistroLog.API.Models
{
    public class Evento
    { 
        [BsonId]
        public Guid Id{ get; private set; }

        public DateTime DataRegistro { get; private set; }

        public DateTime DataAcesso { get;  set; }

        public string Descricao { get;  set; }

        public AcaoObjeto AcaoObjeto { get;  set; }
        public TipoObjeto TipoObjeto { get;  set; }

        public string? IdUsuario { get;  set; }
        public string? NomeUsuario { get;  set; }
        public string? IdObjeto { get;  set; }
        public string? NomeObjeto { get; set; }

        public Evento(DateTime dataAcesso, string descricao, AcaoObjeto acaoObjeto, TipoObjeto tipoObjeto, string idUsuario = null, string nomeUsuario = null, string idObjeto = null, string nomeObjeto = null)
        {
            Id = Guid.NewGuid();
            DataRegistro = DateTime.Now;
            DataAcesso = dataAcesso;
            Descricao = descricao;
            AcaoObjeto = acaoObjeto;
            TipoObjeto = tipoObjeto;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            IdObjeto = idObjeto;
            NomeObjeto = nomeObjeto;
        }

    }
}
