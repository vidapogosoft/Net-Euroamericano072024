

using ModelDatos.Database;

namespace Backend.Ventas.Interfaces
{
    public interface ICategorias
    {

        //GET
        //Colecciones
        IEnumerable<Categorium> ListCategorias { get; }

        IEnumerable<Categorium> ListCategoriaByOrigen(string Origen);

        IEnumerable<Categorium> ListCategoriaByEstado(bool Estado);

        //Objeto = FirstOrDefault
        Categorium? CategoriaById(int IdCategoria);

        //POST
        int InsertCategoria(Categorium NewItem);

        //PUT
        void UpdateCategoria(Categorium EditItem);
        void UpdateCategoria2(int Idcategoria, string Descr, string Nombre);

        //DELETE
        void DeleteCategoria(int Idcategoria);
        void DeleteCategoria2(Categorium DelItem);
    }
}
