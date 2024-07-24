using Microsoft.EntityFrameworkCore;
using ModelDatos.Database;
using ModelDatos.DTO;

namespace Backend.Ventas.DA
{
    public class PostDataPersona
    {


        //@TipoPersona varchar(20),
        //@Nombre varchar(100),
        //@TipoDoc varchar(20),
        //@NumDoc varchar(20),
        //@Direc varchar(70),
        //@Telef varchar(20),
        //@Email varchar(50)

        public List<DTOInsResult> InsertPersona(string TipoPersona, string Nombre, string TipoDoc,
            string NumDoc, string Direc, string Telef, string Email )
        {
            using (var ctx = new dbventasContext())
            {
                return ctx.ResultIns.FromSqlRaw("InsPersona {0},{1},{2},{3},{4},{5},{6}", TipoPersona, 
                    Nombre, TipoDoc, NumDoc, Direc, Telef, Email).ToList();
            }
        }

    }
}
