using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Level.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PropietarioController : ControllerBase
    {
        private readonly PropietarioBL _propietario;

        public PropietarioController(PropietarioBL propietario)
        {
            _propietario = propietario;
        }

        [HttpPost]
        [Route("registrar-propietario")]
        public async Task<IActionResult> RegistrarPropietario([FromBody] PropietarioRequest req)
        {

            try
            {
                var resp = await _propietario.RegistrarPropietario(req);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }


        [HttpGet]
        [Route("obtener-propietarios")]
        public async Task<IActionResult> ObtenerPropietarios()
        {
            try
            {
                var resp = await _propietario.ObtenerPropietarios();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }
        }


    }
}
