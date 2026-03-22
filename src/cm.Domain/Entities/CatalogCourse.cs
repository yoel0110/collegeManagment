using System.ComponentModel.DataAnnotations;
 
namespace cm.Domain.Entities
{
    public class CatalogCourse
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Score { get; set; }
        public int EnrollmentID { get; set; }
        public int ProfesorId { get; set; }    
    }
}
