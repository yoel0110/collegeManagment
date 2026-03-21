using cm.api.Dtos.student;
using cm.Domain.Entities;
using cm.api.Dtos;
using cm.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO studentDTO)
        {
            if (studentDTO.AcademicRecord == null) return BadRequest("Record can't be empty");

            string matricula = "M-" + DateTime.Now.Year + "" + DateTime.Now.Day + "" +  _repository.Count();
            
            var record = _repository.AddAcademicRecord(new AcademicRecord
            {
                Average = 0.0,
                Carreer = studentDTO.AcademicRecord.Carreer,
                CurrentPeriod = 0,
                Matricula = matricula,
                FacultyId = studentDTO.AcademicRecord.FacultyId,
                State = "Admitido",
                YearEnrrollMent = DateOnly.FromDateTime(DateTime.Now),
            });

            var student =  _repository.Add(new Student
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

            return StatusCode(200, ApiResponse<Student>.SuccessResponse(student));
        }
        [HttpGet]
        public  ActionResult<ApiResponse<Student>> GetAll()
        {
            var students = _repository.GetStudents();
            return StatusCode(200, ApiResponse<List<Student>>.SuccessResponse(students, "Ok", 200));
        }

        [HttpGet("get-with-id/{id}")]
        public  ActionResult<Student> GetById(int id)
        {
            var student =  _repository.GetById(id);
            if (student == null) return NoContent();

            return StatusCode(200, ApiResponse<Student>.SuccessResponse(student));
        }

        [HttpGet("get-with-matricula/{matricula}")]
        public  ActionResult<Student> GetByMatricula(string matricula)
        {
            var student = _repository.GetByMatricula(matricula);


            if (student == null) return NoContent();

            return StatusCode(200, ApiResponse<Student>.SuccessResponse(student));
        }
        [HttpPut]
        public ActionResult<Student> Update(UpdateStudentDTO updateStudentDTO)
        {
            Student? student = _repository.GetById(updateStudentDTO.StudentID);
            if (student != null)
            {
                student.FirstName = updateStudentDTO.FirstName;
                student.LastName = updateStudentDTO.LastName;
                student.BirthDate = updateStudentDTO.BirthDate;
                student.Email = updateStudentDTO.Email;
                student.PhoneNumber = updateStudentDTO.PhoneNumber;
                student.Adress = updateStudentDTO.Adress;
                student.Gender = updateStudentDTO.Gender;
                student.Nationality = updateStudentDTO.Nationality;

                _repository.Update(student);
                return StatusCode(200, ApiResponse<Student>.SuccessResponse(student, statusCode: 200));
            }
            return StatusCode(404, ApiResponse<Student>.SuccessResponse(null, statusCode: 404));
        }
        
        [HttpDelete("{matricula}")]
        public ActionResult<AcademicRecord> DeleteByMatricula(string matricula)
        {
            var student =  _repository.DeleteByMatricula(matricula);
            if (student == null) return StatusCode(404, ApiResponse<AcademicRecord>.UnSuccessFullResponse("Student not found"));      
            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(student.AcademicRecord,$"The record matricula {student.AcademicRecord.Matricula} have been removed", 201));
        }

        [HttpGet("records/{matricula}")]
        public ActionResult<AcademicRecord> GetRecord(string matricula)
        {
            var record =  _repository.GetAcademicRecord(matricula);

            if (record == null) return StatusCode(404, ApiResponse<AcademicRecord>.UnSuccessFullResponse(statusCode: 404));

            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(record));
        }

        [HttpPut("update-status")]
        public ActionResult<AcademicRecord> UpdateState(UpdateStateStudentStateDTO update)
        {
            var record = _repository.ChangeState(update.matricula, update.State);
            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(record));
        }
    }
}
