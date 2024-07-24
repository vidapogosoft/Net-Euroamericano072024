using Backend.Ventas.Interfaces;
using Backend.Ventas.DA;
using ModelDatos.Database;

namespace Backend.Ventas.Services
{
    public class CategoriaServices : ICategorias
    {

        public GetDataCategorias dataget = new GetDataCategorias();
        public PostDataCategorias datapost = new PostDataCategorias();


        //GET
        public IEnumerable<Categorium> ListCategorias
        {
            get { return dataget.ListCategorias(); }
        }

        public IEnumerable<Categorium> ListCategoriaByOrigen(string Origen)
        {
            return dataget.ListCategoriaByOrigen(Origen);
        }

        public IEnumerable<Categorium> ListCategoriaByEstado(bool Estado)
        {
            return dataget.ListCategoriaByEstado(Estado);
        }

        public Categorium? CategoriaById(int IdCategoria)
        {
            return dataget.CategoriaById(IdCategoria);
        }

        //POST - PUT - DELETE
        public int InsertCategoria(Categorium NewItem)
        {
            return datapost.InsertCategoria(NewItem);
        }

        public void UpdateCategoria(Categorium EditItem)
        {
            datapost.UpdateCategoria(EditItem);
        }

        public void UpdateCategoria2(int Idcategoria, string Descr, string Nombre)
        {
            datapost.UpdateCategoria2(Idcategoria, Descr, Nombre);
        }

        public void DeleteCategoria(int Idcategoria)
        {
            datapost.DeleteCategoria(Idcategoria);
        }

        public void DeleteCategoria2(Categorium DelItem)
        {
            datapost.DeleteCategoria2(DelItem);
        }

    }
}
