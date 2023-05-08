using System.ComponentModel.DataAnnotations;
namespace PruebaTecnica.Models
{
    public class PrestamoModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRows { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrNombreLibro { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrNombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime DtmFechaPrestamo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime DtmFechaRegreso { get; set; }
    }
}
