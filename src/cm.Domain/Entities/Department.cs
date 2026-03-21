using System.ComponentModel.DataAnnotations;

namespace cm.Domain.Entities
{
    public class Department
    {
        [Key]
        public int DeparmentId { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
