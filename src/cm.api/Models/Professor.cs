namespace cm.api.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? DeparmentID { get; set; }
        public Department? Deparment { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
    }
}
