using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Response
    {
        
        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Resultado { get; set; }

        public bool OK()
        {
            if (Codigo == "200")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
