using System.ComponentModel.DataAnnotations;

namespace cm.Domain.Entities
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Department { get; set; }
    }
}
