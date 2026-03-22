using cm.api.Dtos.student;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using cm.Application.Contract;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO studentDTO)
        {
            try
            {
                var student = _studentService.Register(studentDTO);
                return StatusCode(201, ApiResponse<Student>.SuccessResponse(student, $"The student with id {student.StudentID} have been created", 201));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Student>.UnSuccessFullResponse(ex.Message));
            }

        }
        [HttpGet]
        public ActionResult<ApiResponse<Student>> GetAll()
        {
            var students = _studentService.GetAllStudents();
            return StatusCode(200, ApiResponse<List<Student>>.SuccessResponse(students, "Ok", 200));
        }

        [HttpGet("get-with-id/{id}")]
        public ActionResult<Student> GetById(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);
                if (student == null)
                    return StatusCode(404, ApiResponse<Student>.UnSuccessFullResponse("Estudiante no encontrado"));

                return StatusCode(200, ApiResponse<Student>.SuccessResponse(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Student>.UnSuccessFullResponse(ex.Message));

            }
        }

        [HttpGet("get-with-matricula/{matricula}")]
        public ActionResult<Student> GetByMatricula(string matricula)
        {
            try
            {
                var student = _studentService.GetStudentByMatricula(matricula);
                if (student == null)
                    return StatusCode(404, ApiResponse<Student>.UnSuccessFullResponse("Estudiante no encontrado"));
                return StatusCode(200, ApiResponse<Student>.SuccessResponse(student));
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, ApiResponse<Student>.UnSuccessFullResponse(ex.Message));
                }
            }
        }
        [HttpPut]
        public ActionResult<Student> Update(UpdateStudentDTO updateStudentDTO)
        {
            try
            {
                if (updateStudentDTO == null)
                    return StatusCode(400, ApiResponse<Student>.UnSuccessFullResponse("Datos de estudiante no proporcionados"));

                var student = _studentService.UpdateStudent(updateStudentDTO);
                if (student == null) 
                    return StatusCode(400, ApiResponse<Student>.UnSuccessFullResponse("Estudiante no he encontrado"));

                return StatusCode(200, ApiResponse<Student>.SuccessResponse(student, statusCode: 200));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Student>.UnSuccessFullResponse(ex.Message));
            }
        }

        [HttpDelete("{matricula}")]
        public ActionResult<AcademicRecord> DeleteByMatricula(string matricula)
        {
            var student = _studentService.UpdateStudentState(new UpdateStateStudentStateDTO { Matricula = matricula, State = "Canceled" });
            if (student == null) return StatusCode(404, ApiResponse<AcademicRecord>.UnSuccessFullResponse("Student not found"));
            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(student, $"The student with record {student.Matricula} have been removed", 201));
        }

        [HttpGet("records/{matricula}")]
        public ActionResult<AcademicRecord> GetRecord(string matricula)
        {
            var record = _studentService.GetAcademicRecord(matricula);
            if (record == null) return StatusCode(404, ApiResponse<AcademicRecord>.UnSuccessFullResponse(statusCode: 404));

            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(record));
        }

        [HttpPut("update-status")]
        public ActionResult<AcademicRecord> UpdateState(UpdateStateStudentStateDTO update)
        {
            var record = _studentService.UpdateStudentState(update);
            return StatusCode(200, ApiResponse<AcademicRecord>.SuccessResponse(record));
        }
    }
}
