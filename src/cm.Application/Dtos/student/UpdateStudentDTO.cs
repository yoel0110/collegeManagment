using System.ComponentModel.DataAnnotations;

namespace cm.api.Dtos.student
{
    public class UpdateStudentDTO
    {
        [Required(ErrorMessage = "El ID del estudiante es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del estudiante debe ser mayor a 0")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo debe contener letras y espacios")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        [RegularExpression(@"^(Masculino|Femenino|Otro)$",
            ErrorMessage = "El género debe ser: Masculino, Femenino u Otro")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(35, ErrorMessage = "El email no debe exceder 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [RegularExpression(@"^\+?1?\d{10}$|^(\d{3}-\d{3}-\d{4})$",
            ErrorMessage = "Formato válido: 8091234567 o 809-123-4567")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(65, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 200 caracteres")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "La nacionalidad debe tener entre 3 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La nacionalidad solo debe contener letras y espacios")]
        public string Nationality { get; set; }
    }
}