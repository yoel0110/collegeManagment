namespace cm.Domain.Entities
{
    public class Department
    {
        public int DeparmentId { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public ICollection<Professor> Professors { get; set; }    
    }
}
