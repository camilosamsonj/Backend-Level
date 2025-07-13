using Business;
using Context;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Level.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnidadController : ControllerBase
    {
        private readonly UnidadBL _unidad;

        public UnidadController(UnidadBL unidad)
        {
            _unidad=unidad;
        }

        [HttpPost]
        [Route("registrar-Unidad")]
        public async Task<IActionResult> RegistrarUnidad([FromBody] DepartamentoRequest req)
        {

            try
            {
                var resp = await _unidad.RegistrarUnidad(req);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }


        [HttpPost]
        [Route("buscar-unidades")]
        public async Task<IActionResult> BuscarUnidades(FiltroUnidadRequest req)
        {

            try
            {
                var resp = await _unidad.BuscarUnidades(req);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }


        [HttpPost]
        [Route("obtener-departamentos-todos")]
        public async Task<IActionResult> BuscarUnidades()
        {

            try
            {
                var resp = await _unidad.ObtenerTodosDepartamentos();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }

        [HttpPost]
        [Route("asignar-unidad")]
        public async Task<IActionResult> AsignarUnidad(AsignarUnidadRequest req)
        {

            try
            {
                var resp = await _unidad.AsignarUnidad(req);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Codigo = "500", Mensaje = ex.Message });
            }

        }




    }
}
