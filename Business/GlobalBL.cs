using Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GlobalBL
    {

        private readonly Context.Context _context;

        public GlobalBL(Context.Context context)
        {
            _context = context;
        }





        public async Task<List<Comuna>> ObtenerComunas()
        {
            try
            {
                var comunas = await
                _context.Comuna.ToListAsync();

                return comunas;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }


        }


        public async Task<List<ModeloDepartamento>> ObtenerModelos()
        {
            try
            {
                var modelos = await
                _context.ModeloDepartamento.ToListAsync();

                return modelos;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }


        }

        public async Task<List<Orientacion>> ObtenerOrientaciones()
        {
            try
            {
                var orientaciones = await
                _context.Orientacion.ToListAsync();

                return orientaciones;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }


        }


    }
}
