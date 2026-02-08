using System.ComponentModel.DataAnnotations;

namespace cm.api.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollMentID { get; set; }
        public int RecordID { get; set; }
        public AcademicRecord AcademicRecord { get; set; }
        public int SubjectId { get; set; }
        public CatalogCourse CatalogCourse { get; set; }
        public DateOnly EnrollDate { get; set; }
        public string Status { get; set; }
    }
}
