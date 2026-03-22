
namespace cm.api.Dtos.professor
{
    public class CreateProfessorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
        public int CatalogId { get; set; }
    }
}
