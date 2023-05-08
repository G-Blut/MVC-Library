using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class LibroModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRows  { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrNombreLibro { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrNomAutor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrLuNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime DtmNacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime DtmPublicacion { get; set; }
    }
}
