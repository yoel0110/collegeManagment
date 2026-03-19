using System.ComponentModel.DataAnnotations;

namespace cm.api.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        public string Name { get; set; }
    }
}
