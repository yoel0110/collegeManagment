using cm.Domain.Entities;
 

namespace cm.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        public Student Add(Student student);
        public Student Update(Student student);
        public AcademicRecord DeleteByMatricula(string matricula);
        public Student GetById(int id);
        public Student GetByMatricula(string matricula);
        public List<Student> GetStudents();
        public AcademicRecord AddAcademicRecord(AcademicRecord _record);
        public AcademicRecord GetAcademicRecord(string matricula);
        public AcademicRecord ChangeState(string matricula, string state);
        public int Count();
    }
}
