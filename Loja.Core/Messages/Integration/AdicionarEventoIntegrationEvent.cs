using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Core.Messages.Integration
{
    public class AdicionarEventoIntegrationEvent : IntegrationEvent
    {
        

         public DateTime DataAcesso { get; private set; }
        public string Descricao { get; private set; }
        public int AcaoObjeto { get; private set; }
        public int TipoObjeto { get; private set; }
        public string IdUsuario { get; private set; }
        public string NomeUsuario { get; private set; }
        public string IdObjeto { get; private set; }
        public string NomeObjeto { get; private set; }

        //public AdicionarEventoIntegrationEvent(DateTime dataAcesso, 
        //                                        string descricao, 
        //                                        int acaoObjeto, 
        //                                        int tipoObjeto)
        //{
        //    DataAcesso = dataAcesso;
        //    Descricao = descricao;
        //    AcaoObjeto = acaoObjeto;
        //    TipoObjeto = tipoObjeto;
        //}

        public AdicionarEventoIntegrationEvent(DateTime dataAcesso,
                                                string descricao,
                                                int acaoObjeto,
                                                int tipoObjeto,
                                                string idUsuario,
                                                string nomeUsuario,
                                                string idObjeto,
                                                string nomeObjeto)
        {
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
