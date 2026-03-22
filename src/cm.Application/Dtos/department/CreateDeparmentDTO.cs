using System.ComponentModel.DataAnnotations;

namespace cm.Application.Dtos.department
{
    public class CreateDeparmentDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El ID de la facultad es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la facultad debe ser mayor a 0")]
        public int FacultyId { get; set; }
    }
}