namespace cm.Application.Dtos.enrollment
{
    public class CreateEnrollmentDTO
    {
        public int RecordID { get; set; }
        public int SubjectId { get; set; }
        public DateOnly EnrollDate { get; set; }
        public string Status { get; set; }

    }
}
