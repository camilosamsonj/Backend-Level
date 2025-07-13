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
    public class UnidadBL
    {

        private readonly Context.Context _context;

        public UnidadBL(Context.Context context)
        {
            _context = context;
        }


        public async Task<Response> RegistrarUnidad(DepartamentoRequest req)
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"
                };

                var result = await _context.Procedures.sp_RegistrarDepartamentoAsync(
                   req.Numero,
                   req.IdOrientacion,
                   req.Direccion,
                   req.NumeracionDireccion,
                   req.IdComuna,
                   req.CantidadDormitorios,
                   req.CantidadBanos,
                   req.PrecioArriendo,
                   req.PrecioGastoComun,
                   req.IdTipoCocina
                    );

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

        public async Task<Response> BuscarUnidades(FiltroUnidadRequest req)
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"

                };

                var totalCount = new OutputParameter<int?>();

                var result = await _context.Procedures.sp_BuscarDepartamentosAsync(
                  req.PalabraClave,
                  req.Rut,
                  req.NumeroUnidad,
                  req.Ubicacion,
                  req.NumeroPagina,
                  req.TamanoPagina,
                  totalCount
                  );

                var resultadosDTO = result.Select(x => new DTODepartamento
                {
                    Id = x.DepartamentoId,
                    Numero = x.NumeroDepartamento,
                    Orientacion = x.Orientacion,
                    Direccion = x.DireccionCompleta,
                    CantidadDormitorios = x.CantidadDormitorios,
                    CantidadBanos = x.CantidadBanos,
                    Modelo = x.Modelo,
                    PrecioArriendo = x.PrecioArriendo,
                    PrecioGastoComun = x.PrecioGastoComun,
                    Propietarios = (x.Propietarios != " (%)" ? x.Propietarios : "Sin propietarios")
                }).ToList();

                
                int totalItems = totalCount.Value ?? 0;
      
                int tamanoPagina = req.TamanoPagina ?? 10;

            
                int totalPages = (tamanoPagina > 0)
                    ? (int)Math.Ceiling((double)totalItems / tamanoPagina)
                    : 0;


                var respuestaPaginada = new
                {
                    items = resultadosDTO,
                    totalItems = totalItems,
                    totalPages = totalPages,
                    currentPage = req.NumeroPagina ?? 1
                };

                response.Resultado = respuestaPaginada;
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


        public async Task<Response> ObtenerTodosDepartamentos()
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"

                };

                var result = await _context.Procedures.sp_BuscarDepartamentos_TodosAsync(
                  );

                var resultadosDTO = result.Select(x => new DTODepartamentosTodos
                {
                    Id = x.Id,
                   Departamento = x.Departamento
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


        public async Task<Response> AsignarUnidad(AsignarUnidadRequest req)
        {
            try
            {
                var response = new Response()
                {
                    Codigo = "1",
                    Mensaje = "Ok"

                };

                var result = await _context.Procedures.sp_AsignarUnidadAsync(req.IdPropietario, req.IdDepartamento, req.PorcentajePropiedad
                  );

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
