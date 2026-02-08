using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace cm.api.Models
{
    public class AcademicRecord
    {
        public int RecordID { get; set; }
        [NotNull, Required]
        public int StudentID { get; set; }
        public string Matricula { get; set; }
        public string Carreer { get; set; }
        public int FacultyId { get; set; }
        public DateOnly YearEnrrollMent { get; set; }
        public int CurrentPeriod { get; set; }
        public float Average { get; set; }
        public string State { get; set; }
    }
}
