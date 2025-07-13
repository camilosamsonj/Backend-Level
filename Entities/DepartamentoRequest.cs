using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DepartamentoRequest
    {

        public string Numero { get; set; }
        public string Direccion { get; set; }
        public string NumeracionDireccion { get; set; }
        public int IdComuna { get; set; }
        public int IdOrientacion { get; set; }

        public int IdModeloDepto { get; set; }
        public int CantidadDormitorios { get; set; }

        public int CantidadBanos { get; set; }
        public int PrecioArriendo { get; set; }

        public int PrecioGastoComun { get; set; }

        public int IdTipoCocina { get; set; }
    }
}
