using System;
using System.Collections.Generic;

namespace ModelDatos.Database
{
    public partial class Persona
    {
        public Persona()
        {
            Ingresos = new HashSet<Ingreso>();
            Venta = new HashSet<Ventum>();
        }

        public int Idpersona { get; set; }
        public string TipoPersona { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
