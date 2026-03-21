using cm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace cm.Infrastructure.Interfaces
{
    internal interface IAcedemicRecordRepository
    {
        public AcademicRecord Add(AcademicRecord record);
        public AcademicRecord Update(AcademicRecord record);
        public AcademicRecord Delete(AcademicRecord record);
        public List<AcademicRecord> GetAcademicRecords();
        public AcademicRecord GetById(int recordId);
    }
}
