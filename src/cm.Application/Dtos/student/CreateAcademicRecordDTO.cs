using System.ComponentModel.DataAnnotations;

namespace cm.api.Dtos.student
{
    public class CreateAcademicRecordDTO
    {
        [Required(ErrorMessage = "La carrera es obligatoria")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "La carrera debe tener entre 3 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La carrera solo debe contener letras y espacios")]
        public string Carreer { get; set; }

        [Required(ErrorMessage = "El ID de la facultad es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la facultad debe ser mayor a 0")]
        public int FacultyId { get; set; }
    }
}