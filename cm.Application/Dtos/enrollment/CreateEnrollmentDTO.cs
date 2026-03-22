using System.ComponentModel.DataAnnotations;

namespace cm.Application.Dtos.enrollment
{
    public class CreateEnrollmentDTO
    {
        [Required(ErrorMessage = "El ID del récord académico es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del récord académico debe ser mayor a 0")]
        public int RecordID { get; set; }

        [Required(ErrorMessage = "El ID de la materia es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la materia debe ser mayor a 0")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "La fecha de inscripción es obligatoria")]
        public DateOnly EnrollDate { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression(@"^(Activo|Inactivo|Pendiente|Completado)$",
            ErrorMessage = "El estado debe ser: Activo, Inactivo, Pendiente o Completado")]
        public string Status { get; set; }
    }
}