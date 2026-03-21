using cm.Domain.Entities;
 

namespace cm.Infrastructure.Interfaces
{
    public interface IAcedemicRecordRepository
    {
        public AcademicRecord Add(AcademicRecord record);
        public AcademicRecord Update(AcademicRecord record);
        public AcademicRecord Delete(AcademicRecord record);
        public List<AcademicRecord> GetAcademicRecords();
        public AcademicRecord GetById(int recordId);
        public AcademicRecord GetByMatricula(string matriculaId);
        public AcademicRecord UpdateState(string matricula, string state);

    }
}
