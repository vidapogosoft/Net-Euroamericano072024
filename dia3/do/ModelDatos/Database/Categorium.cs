using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class Categorium
    {
        public Categorium()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int Idcategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
