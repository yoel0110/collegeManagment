using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace cm.api.Models
{
    public class AcademicRecord
    {
        [Key]
        public int RecordID { get; set; }
        public required string Matricula { get; set; }
        public string Carreer { get; set; }
        public int FacultyId { get; set; }
        public DateOnly YearEnrrollMent { get; set; }
        public int CurrentPeriod { get; set; }
        public double Average { get; set; }
        public string State { get;set; }
 
    }
}
