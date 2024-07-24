using Backend.Ventas.Models.DTO;
using ModelDatos.Database;
using ModelDatos.DTO;

namespace Backend.Ventas.DA
{
    public class GetDataPersona
    {
        public List<DTOUsuarios> ListUsuarios()
        {
            using (var ctx = new dbventasContext())
            {

                var listlinq = (

                    from a in ctx.Usuarios
                    join b in ctx.Personas on a.NumDocumento equals b.NumDocumento
                    join c in ctx.Rols on a.Idrol equals c.Idrol
                    orderby a.NumDocumento descending

                    select new DTOUsuarios()
                    {
                        Usuario = a.Email,
                        Clave = a.Password,
                        Registrado = b.Nombre,
                        TipoPersona = b.TipoPersona,
                        Rol = c.Nombre,
                        Funciones = c.Descripcion
                    }).ToList();

                return listlinq;
            }
        }
    }
}
