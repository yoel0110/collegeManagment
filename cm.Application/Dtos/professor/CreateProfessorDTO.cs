using System.ComponentModel.DataAnnotations;

namespace cm.Application.Dtos.professor
{
    public class CreateProfessorDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El apellido solo debe contener letras y espacios")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(30, ErrorMessage = "El email no debe exceder 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [RegularExpression(@"^\+?1?\d{10}$|^(\d{3}-\d{3}-\d{4})$",
            ErrorMessage = "Formato válido: 8091234567 o 809-123-4567")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El ID del departamento es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del departamento debe ser mayor a 0")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "La especialidad debe tener entre 3 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "La especialidad solo debe contener letras y espacios")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression(@"^(Activo|Inactivo)$",
            ErrorMessage = "El estado debe ser: Activo o Inactivo")]
        public string Status { get; set; }

        [Required(ErrorMessage = "El ID del catálogo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del catálogo debe ser mayor a 0")]
        public int CatalogId { get; set; }
    }
}