namespace cm.Domain.Entities
{
    public class Enrollment
    {
        public int EnrollMentID { get; set; }
        public int RecordID { get; set; }
        public AcademicRecord AcademicRecord { get; set; }
        public int SubjectId { get; set; }
        public ICollection<CatalogCourse> CatalogCourse { get; set; }
        public DateOnly EnrollDate { get; set; }
        public string Status { get; set; }
    }
}
