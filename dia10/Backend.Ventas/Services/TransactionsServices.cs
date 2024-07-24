using Backend.Ventas.DA;
using Backend.Ventas.Interfaces;
using Backend.Ventas.Models.DTO;
using ModelDatos.Database;
using ModelDatos.DTO;
using System.Data;

namespace Backend.Ventas.Services
{
    public class TransactionsServices : ITransactions
    {
        public PostDataPersona TranPost = new PostDataPersona();
        public GetDataPersona TranGet = new GetDataPersona();

        public IEnumerable<DTOInsResult> InsertPersona(string TipoPersona, string Nombre, string TipoDoc, 
            string NumDoc, string Direc, string Telef, string Email)
        {
            return TranPost.InsertPersona(TipoPersona, Nombre, TipoDoc, NumDoc, Direc, Telef, Email);
        }

        public IEnumerable<DTOUsuarios> ListUsuarios
        {
            get { return TranGet.ListUsuarios(); }
        }

    }
}
