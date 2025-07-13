using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PropietarioRequest
    {
  
        public string Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public long IdDepartamento { get; set; }

        public decimal PorcentajePropiedad { get; set; }
    }
}
