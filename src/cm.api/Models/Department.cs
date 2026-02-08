using System.ComponentModel.DataAnnotations;

namespace cm.api.Models
{
    public class Department
    {
        [Key]
        public int DeparmentId { get; set; }
        public string Name { get; set; }
        public string FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
