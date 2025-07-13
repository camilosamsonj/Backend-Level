using Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities
{
    public class DTODepartamento
    {
            public int? Id { get; set; }
            public string Direccion { get; set; }
            public string Numero { get; set; }
            public string Orientacion { get; set; }
            public string Modelo { get; set; }
            public int? CantidadDormitorios { get; set; }
            public int? CantidadBanos { get; set; }
            public int? PrecioArriendo { get; set; }
            public int? PrecioGastoComun { get; set; }
            public string Propietarios { get; set; }
            public string RutsPropietarios { get; set; }
        
    }
}

