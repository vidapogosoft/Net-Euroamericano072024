namespace Backend.Ventas.Models.DTO
{
    public class DTOUsuarios
    {
        public string Usuario { get; set; } = null!;
        public string Clave  { get; set; } = null!;
        public string Registrado { get; set; } = null!;
        public string TipoPersona { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string? Funciones { get; set; }
    }
}
