using Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PropietarioBL
    {

        private readonly Context.Context _context;

        public PropietarioBL(Context.Context context)
        {
            _context = context;
        }

        public async Task<Response> ObtenerPropietarios()
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"
                };

                var propietarios = await _context.Propietario.ToListAsync();

                var resultadosDTO = propietarios.Select(x => new DTOPropietario
                {
                    Id = x.Id,
                    InfoPropietario = $"{x.Nombre + ' ' + '-' + ' '  + x.Rut + '-' + x.Dv}",
                    
                }).ToList();


                response.Resultado = resultadosDTO;
                return response;

            }
            catch (Exception e)
            {
                var response = new Response();
                response.Codigo = "-1";
                response.Mensaje = e.Message;
                return response;
            }


        }
        public async Task<Response> RegistrarPropietario(PropietarioRequest req)
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"
                };

                var result = await _context.Procedures.sp_RegistrarPropietario_AsignarUnidadAsync(
                    req.Rut,
                    req.Dv,
                    req.Nombre,
                    req.FechaNacimiento,
                    req.CorreoElectronico,
                    req.IdDepartamento,
                    req.PorcentajePropiedad
                    );

                var primerResultado = result.FirstOrDefault();



                if (primerResultado != null)
                {
                    response.Resultado = (long)primerResultado.NuevoPropietarioId;
                }

                return response;


            }
            catch (Exception e)
            {
                var response = new Response();
                response.Codigo = "-1";
                response.Mensaje = e.Message;
                return response;
            }


        }


    }
}


