using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Student DeleteByMatricula(string matricula)
        {
            var student = _context.Students
               .Include(e => e.AcademicRecord)
               .FirstOrDefault(e => e.AcademicRecord.Matricula == matricula);

            student?.AcademicRecord?.State = "Canceled";
            if (student != null)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                _context.Entry(student).Reload();
                return student;
            }
            return null;
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

            var student = _context.Students
                .Include(e => e.AcademicRecord)
                .FirstOrDefault(e => e.AcademicRecord.Matricula == matricula);
            return student;
        }

        public List<Student> GetStudents()
        {
            var student = _context.Students
                .Include(e => e.AcademicRecord)
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
