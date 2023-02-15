using System;
using System.Collections.Generic;

namespace LojaVirtual.API.ViewModels
{
    public class FiltroViewModel
    {
        public List<int> GeneroIds { get; set; }
        public List<Guid> Ids { get; set; }
        public TipoFiltroViewModel TipoFiltro { get; set; }
    }
}
