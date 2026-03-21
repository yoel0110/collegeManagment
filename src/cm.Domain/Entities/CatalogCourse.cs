using System.ComponentModel.DataAnnotations;
 
namespace cm.Domain.Entities
{
    public class CatalogCourse
    {
        [Key]
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Score { get; set; }
    }
}
