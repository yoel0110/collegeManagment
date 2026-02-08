using System.ComponentModel.DataAnnotations;

namespace cm.api.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Department Department { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
        public CatalogCourse CatalogCourse { get; set; }
    }
}
