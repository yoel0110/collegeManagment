using System.ComponentModel.DataAnnotations;

namespace cm.Application.Dtos.faculty
{
    public class CreateFacultyDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
        public string Name { get; set; }
    }
}