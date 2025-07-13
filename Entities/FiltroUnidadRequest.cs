using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FiltroUnidadRequest
    {
        public string? PalabraClave { get; set; }

        public string? Rut { get; set; }

        public string? NumeroUnidad { get; set; }

        public string? Ubicacion { get; set; }

        public int? NumeroPagina { get; set; }

        public int? TamanoPagina { get; set; }

    }
}
