using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class EstudianteModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRows { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? StrNombre { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int IntDocumento { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string? StrPrograma { get; set; }
    }
}
