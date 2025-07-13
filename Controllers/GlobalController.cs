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

    public class GlobalController : ControllerBase
    {
        private readonly GlobalBL _global;

        public GlobalController(GlobalBL global)
        {
            _global=global;
        }

        [HttpGet]
        [Route("obtener-comunas")]
        public async Task<IActionResult> ObtenerComunas()
        {
           
            try
            {
                var resp = await _global.ObtenerComunas();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }

        [HttpGet]
        [Route("obtener-modelos")]
        public async Task<IActionResult> ObtenerModelos()
        {
           
            try
            {
                var resp = await _global.ObtenerModelos();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }

        [HttpGet]
        [Route("obtener-orientaciones")]
        public async Task<IActionResult> ObtenerOrientaciones()
        {
           
            try
            {
                var resp = await _global.ObtenerOrientaciones();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }


    }
}
