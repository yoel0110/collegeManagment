using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace cm.api.Models
{
    public class CatalogCourse
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Score { get; set; }
        [NotNull, Required, ForeignKey(nameof(ProfessorID))]
        public int ProfessorID { get; set; }
    }
}
