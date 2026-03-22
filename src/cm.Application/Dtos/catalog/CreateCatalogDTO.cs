using System.ComponentModel.DataAnnotations;

namespace cm.Application.Dtos.catalog
{
    public class CreateCatalogDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "El código debe tener entre 2 y 10 caracteres")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "El código solo puede contener letras mayúsculas y números")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El score es obligatorio")]
        [Range(0.0, 10.0, ErrorMessage = "El score debe estar entre 0 y 10")]
        public float Score { get; set; }
    }
}