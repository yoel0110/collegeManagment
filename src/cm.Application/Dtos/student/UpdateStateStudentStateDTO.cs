using System.ComponentModel.DataAnnotations;

namespace cm.api.Dtos.student
{
    public class UpdateStateStudentStateDTO
    {
        [Required(ErrorMessage = "La matrícula es obligatoria")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "La matrícula debe tener entre 3 y 20 caracteres")]
        [RegularExpression(@"^[A-Z0-9\-]+$", ErrorMessage = "La matrícula solo debe contener letras mayúsculas, números y guiones")]
        public required string Matricula { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression(@"^(Activo|Inactivo|Suspendido|Graduado)$",
            ErrorMessage = "El estado debe ser: Activo, Inactivo, Suspendido o Graduado")]
        public string State { get; set; }
    }
}