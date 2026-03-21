using System.ComponentModel.DataAnnotations;

namespace cm.Domain.Entities
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        public string Name { get; set; }
    }
}
