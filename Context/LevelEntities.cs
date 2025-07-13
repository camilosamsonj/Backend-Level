using Microsoft.EntityFrameworkCore;

namespace Context
{
    public static class LevelEntities
    {

        public static string? Conexion;

        public static Context Entidades()
        {
            Context context = new Context();
            context.Database.SetConnectionString(Conexion);
            return context;
        }

        public static ContextProcedures Procedimientos()
        {
            var ctx = new Context();
            ctx.Database.SetConnectionString(Conexion);
            var context = new ContextProcedures(ctx);
            return context;
        }


    }
}
