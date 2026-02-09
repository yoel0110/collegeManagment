using System.ComponentModel.DataAnnotations;

namespace cm.api.Dtos
{
    public class UpdateStudentDTO
    {
        [Required]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string Nationality { get; set; }
    }
}
