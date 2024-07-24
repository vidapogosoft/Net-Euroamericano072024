using ModelDatos.Database;

namespace Backend.Ventas.DA
{
    public class PostDataCategorias
    {
        public int InsertCategoria(Categorium NewItem)
        {
            using (var ctx = new dbventasContext())
            {
                ctx.Categoria.Add(NewItem);
                ctx.SaveChanges();

                return NewItem.Idcategoria;
            }
        }

        public void UpdateCategoria(Categorium EditItem)
        {
            using (var ctx = new dbventasContext())
            {
                var reg = ctx.Categoria.Where(a => a.Idcategoria == EditItem.Idcategoria).FirstOrDefault();

                if(reg != null) 
                {
                    reg.Descripcion = EditItem.Descripcion;
                    reg.Nombre = EditItem.Nombre;

                    ctx.SaveChanges();
                }
            }
        }


        public void UpdateCategoria2(int Idcategoria, string Descr, string Nombre)
        {
            using (var ctx = new dbventasContext())
            {
                var reg = ctx.Categoria.Where(a => a.Idcategoria == Idcategoria).FirstOrDefault();

                if (reg != null)
                {
                    reg.Descripcion = Descr;
                    reg.Nombre = Nombre;

                    ctx.SaveChanges();
                }
            }
        }

        public void DeleteCategoria(int Idcategoria)
        {
            using (var ctx = new dbventasContext())
            {
                var reg = ctx.Categoria.Where(a => a.Idcategoria == Idcategoria).FirstOrDefault();

                if (reg != null)
                {
                    ctx.Categoria.Remove(reg);
                    
                    ctx.SaveChanges();
                }
            }
        }

        public void DeleteCategoria2(Categorium DelItem)
        {
            using (var ctx = new dbventasContext())
            {
                ctx.Categoria.Remove(DelItem);
                ctx.SaveChanges();
            }
        }

    }
}
