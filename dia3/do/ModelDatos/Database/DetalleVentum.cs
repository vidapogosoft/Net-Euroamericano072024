using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class DetalleVentum
    {
        public int IddetalleVenta { get; set; }
        public int Idventa { get; set; }
        public int Idarticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        public virtual Articulo IdarticuloNavigation { get; set; } = null!;
        public virtual Ventum IdventaNavigation { get; set; } = null!;
    }
}
