namespace cm.Domain.Entities
{
    public class AcademicRecord
    {
        public int RecordID { get; set; }
        public required string Matricula { get; set; }
        public string Carreer { get; set; }
        public int FacultyId { get; set; }
        public DateOnly YearEnrrollMent { get; set; }
        public int CurrentPeriod { get; set; }
        public double Average { get; set; }
        public string State { get; set; }
        public int StudentId {  get; set; }
        public Student Student { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
