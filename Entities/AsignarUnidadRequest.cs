using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AsignarUnidadRequest
    {
        public long IdPropietario { get; set; }
        public long IdDepartamento { get; set; }

        public decimal PorcentajePropiedad { get; set; }
    }
}
