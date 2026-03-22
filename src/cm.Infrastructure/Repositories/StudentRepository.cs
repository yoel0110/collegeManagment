using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;

namespace cm.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IAcedemicRecordRepository _acedemicRecordRepository;
        public StudentRepository(AppDbContext context, IAcedemicRecordRepository acedemicRecordRepository)
        {
            _context = context;
            _acedemicRecordRepository = acedemicRecordRepository;
        }

        public AcademicRecord AddAcademicRecord(AcademicRecord _record)
        {
            var record = _acedemicRecordRepository.Add(_record);
            return record;
        }

        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public AcademicRecord DeleteByMatricula(string matricula)
        {
            var record = _acedemicRecordRepository.GetByMatricula(matricula);
            record.State = "Canceled";
            record = _acedemicRecordRepository.Update(record);
            return record;
        }

        public Student GetById(int id)
        {
            var student = _context.Students
                .Find(id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public Student GetByMatricula(string matricula)
        {
            var record = _acedemicRecordRepository.GetByMatricula(matricula);

            var student = _context.Students.Find(record.StudentId);
                
            if (student == null) return null;
            return student;
        }

        public List<Student> GetStudents()
        {
            var student = _context.Students
                .ToList();

            return student;
        }

        public Student Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            _context.Entry(student).Reload();
            return student;
        }

        public int Count()
        {
            return _context.Students.Count() + 1;
        }

        public AcademicRecord GetAcademicRecord(string matricula)
        {
            var academicRecord = _acedemicRecordRepository.GetByMatricula(matricula);
            if (academicRecord == null)
                return null;

            return academicRecord;
        }

        public AcademicRecord ChangeState(string matricula, string state)
        {
            var record = _acedemicRecordRepository.UpdateState(matricula, state);
            return record;
        }
    }
}
