using cm.Domain.Entities;

namespace cm.api.Dtos.professor
{
    public class UpdateProfessorDTO
    {
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
