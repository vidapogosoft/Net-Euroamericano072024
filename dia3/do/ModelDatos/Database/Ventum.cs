using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Idventa { get; set; }
        public int Idcliente { get; set; }
        public int Idusuario { get; set; }
        public string TipoComprobante { get; set; } = null!;
        public string? SerieComprobante { get; set; }
        public string NumComprobante { get; set; } = null!;
        public DateTime FechaHora { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Persona IdclienteNavigation { get; set; } = null!;
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
