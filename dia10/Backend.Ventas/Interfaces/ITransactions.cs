using Backend.Ventas.Models.DTO;
using ModelDatos.Database;
using ModelDatos.DTO;

namespace Backend.Ventas.Interfaces
{
    public interface ITransactions
    {

        IEnumerable<DTOInsResult> InsertPersona(string TipoPersona, string Nombre, string TipoDoc,
            string NumDoc, string Direc, string Telef, string Email);


        IEnumerable<DTOUsuarios> ListUsuarios { get; }
    }
}
