using System.ComponentModel.DataAnnotations.Schema;

namespace cm.Domain.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Nationality { get; set; }
        public int RecordId { get; set; }
        public AcademicRecord? AcademicRecord { get; set; }
    }
}
