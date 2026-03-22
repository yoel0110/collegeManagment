using cm.api.Dtos.student;
using cm.Application.Contract;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;

namespace cm.Application.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAcedemicRecordRepository _acedemicRecordRepository;

        public StudentService(IStudentRepository studentRepository, IAcedemicRecordRepository acedemicRecordRepository)
        {
            _acedemicRecordRepository = acedemicRecordRepository;
            _studentRepository = studentRepository;
        }

        public Enrollment ErrollStudent(string matricula, int sujectId)
        {
            try
            {
                var record = _acedemicRecordRepository.GetByMatricula(matricula);
                if (record == null) throw new Exception("Academic record not found");
                var enrollment = new Enrollment
                {
                    RecordID = record.RecordID,
                    SubjectId = sujectId,
                    EnrollDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "Enrolled"
                };

                return enrollment;

            }
            catch (Exception ex)
            {
                throw new Exception("Error enrolling student: " + ex.Message);
            }
        }

        public AcademicRecord GetAcademicRecord(string matricula)
        {
            try
            {
                var record = _acedemicRecordRepository.GetByMatricula(matricula);
                return record;

            }
            catch (Exception ex)
            {
                throw new Exception("Error getting academic record: " + ex.Message);
            }
        }

        public AcademicRecord GetAcademicRecord(int id)
        {
            try
            {
                var record = _acedemicRecordRepository.GetById(id);
                return record;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting academic record: " + ex.Message);
            }
        }
        public List<Student> GetAllStudents()
        {
            var students = _studentRepository.GetStudents();
            return students;
        }

        public Student GetStudent(int id)
        {
            try
            {
                var student = _studentRepository.GetById(id);
                return student;

            }
            catch (Exception ex)
            {
                throw new Exception("Error getting student: " + ex.Message);
            }
        }

        public Student GetStudentByMatricula(string matricula)
        {
            var student = _studentRepository.GetByMatricula(matricula);
            return student;

        }

        public Student Register(CreateStudentDTO studentDTO)
        {
            if (studentDTO.AcademicRecord == null) throw new ArgumentException("Record can't be empty");

            string matricula = "M-" + DateTime.Now.Year + "" + DateTime.Now.Day + "" + _studentRepository.Count();

            var record = _acedemicRecordRepository.Add(new AcademicRecord
            {
                Average = 0.0,
                Carreer = studentDTO.AcademicRecord.Carreer,
                CurrentPeriod = 0,
                Matricula = matricula,
                FacultyId = studentDTO.AcademicRecord.FacultyId,
                State = "Admitido",
                YearEnrrollMent = DateOnly.FromDateTime(DateTime.Now),
            });

            var student = _studentRepository.Add(new Student
            {
                FirstName = studentDTO.FirstName,
                BirthDate = studentDTO.BirthDate,
                PhoneNumber = studentDTO.PhoneNumber,
                Adress = studentDTO.Adress,
                LastName = studentDTO.LastName,
                Email = studentDTO.Email,
                Gender = studentDTO.Gender,
                Nationality = studentDTO.Nationality,
                RecordId = record.RecordID,

            });

            record.StudentId = student.StudentID;
            _acedemicRecordRepository.Update(record);
            return student;
        }

        public Student UpdateStudent(UpdateStudentDTO studentDTO)
        {
            var student = _studentRepository.GetById(studentDTO.StudentID);
            if (student == null) throw new Exception("Student not found");

            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.BirthDate = studentDTO.BirthDate;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.Adress = studentDTO.Adress;
            student.Email = studentDTO.Email;
            student.Gender = studentDTO.Gender;
            student.Nationality = studentDTO.Nationality;

            student = _studentRepository.Update(student);
            return student;
        }

        public AcademicRecord UpdateStudentState(UpdateStateStudentStateDTO stateStudentStateDTO)
        {
            var record = _acedemicRecordRepository.GetByMatricula(stateStudentStateDTO.Matricula);
            if (record == null) throw new Exception("Academic record not found");
            record.State = stateStudentStateDTO.State;
            _acedemicRecordRepository.Update(record);
            return record;
        }
    }
}
