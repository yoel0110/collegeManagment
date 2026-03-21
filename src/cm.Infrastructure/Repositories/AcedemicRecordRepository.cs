using cm.Infrastructure.Interfaces;
using cm.Infrastructure.Context;
using cm.Domain.Entities;

namespace cm.Infrastructure.Repositories
{
    public class AcedemicRecordRepository: IAcedemicRecordRepository
    {
        private readonly AppDbContext _context;
        public AcedemicRecordRepository(AppDbContext context) { 
            _context = context;
        }

        public AcademicRecord Add(AcademicRecord record)
        {
            _context.AcademicRecords.Add(record);
            _context.SaveChanges();
            return record;
        }

        public AcademicRecord Delete(AcademicRecord record)
        {
            record.State = "Canceled";
            _context.AcademicRecords.Update(record);
            _context.SaveChanges();
            return record;
        }

        public List<AcademicRecord> GetAcademicRecords()
        {
            var records = _context.AcademicRecords.ToList();
            return records;
        }

        public AcademicRecord GetById(int recordId)
        {
            var record = _context.AcademicRecords.Find(recordId);
            if (record == null)
            {
                return null;
            }

            return record;
        }

        public AcademicRecord Update(AcademicRecord record)
        {
            _context.AcademicRecords.Update(record);
            _context.SaveChanges();

            return record;
        }
    }
}
