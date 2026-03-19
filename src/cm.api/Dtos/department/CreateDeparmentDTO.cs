using cm.api.Dtos.faculty;
using cm.api.Models;

namespace cm.api.Dtos.department
{
    public class CreateDeparmentDTO
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }
}
