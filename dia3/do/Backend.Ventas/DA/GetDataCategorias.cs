
using System.Linq;
using Backend.Ventas.Controllers;
using ModelDatos.Database;

namespace Backend.Ventas.DA
{
    public class GetDataCategorias
    {
        public List<Categorium> ListCategorias()
        {
            using (var ctx = new dbventasContext())
            {
                return ctx.Categoria.ToList();
            }
        }


        public List<Categorium> ListCategoriaByOrigen(string Origen)
        {
            using (var ctx = new dbventasContext())
            {
                return ctx.Categoria.Where(x => x.Descripcion == Origen && x.Estado == true).OrderByDescending(a => a.Idcategoria).ToList();
            }

        }

        public List<Categorium> ListCategoriaByEstado(bool Estado)
        {
            using (var ctx = new dbventasContext())
            {
                return ctx.Categoria.Where(x => x.Estado == Estado).OrderByDescending(a => a.Idcategoria).ToList();
            }

        }

        public Categorium? CategoriaById(int IdCategoria)
        {
            using (var ctx = new dbventasContext())
            {
                return ctx.Categoria.Where(a => a.Estado == true && a.Idcategoria == IdCategoria)
                    .FirstOrDefault();
            }
        }
    }
}
