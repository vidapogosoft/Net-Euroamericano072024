
using System.ComponentModel.DataAnnotations;

namespace ModelDatos.DTO
{
    public class DTOInsResult
    {
        [Key]
        public int CodTran { get; set; }
        public string? Mensaje { get; set; }
    }
}
