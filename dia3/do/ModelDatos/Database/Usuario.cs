using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ingresos = new HashSet<Ingreso>();
            Venta = new HashSet<Ventum>();
        }

        public int Idusuario { get; set; }
        public int Idrol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual Rol IdrolNavigation { get; set; } = null!;
        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
