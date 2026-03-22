using System.ComponentModel.DataAnnotations;

namespace cm.api.Dtos.catalog
{
    public class UpdateCatalogDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Score { get; set; }
        [Required]
        public int ProfessorID { get; set; }
    }
}
