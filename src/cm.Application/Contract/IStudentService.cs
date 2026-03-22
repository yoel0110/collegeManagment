using cm.api.Dtos.student;
using cm.Domain.Entities;

namespace cm.Application.Contract
{
    public interface IStudentService
    {
        public Student Register(CreateStudentDTO studentDTO);
        public Student GetStudent(int id);
        public List<Student> GetAllStudents();
        public Student GetStudentByMatricula(string  matricula);
        public AcademicRecord GetAcademicRecord(string matricula);
        public AcademicRecord GetAcademicRecord(int id);
        public Student UpdateStudent(UpdateStudentDTO studentDTO);
        public AcademicRecord UpdateStudentState(UpdateStateStudentStateDTO stateStudentStateDTO);
        public Enrollment ErrollStudent(string matricula, int sujectId);
    }
}
