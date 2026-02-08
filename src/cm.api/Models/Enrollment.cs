namespace cm.api.Models
{
    public class Enrollment
    {
        public int EnrollMentID { get; set; }
        public int RecordID { get; set; }
        public int SubjectId { get; set; }
        public DateOnly EnrollDate { get; set; }
        public string Status { get; set; }
    }
}
