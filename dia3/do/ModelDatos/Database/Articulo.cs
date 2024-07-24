using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleIngresos = new HashSet<DetalleIngreso>();
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Idarticulo { get; set; }
        public int Idcategoria { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual Categorium IdcategoriaNavigation { get; set; } = null!;
        public virtual ICollection<DetalleIngreso> DetalleIngresos { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
