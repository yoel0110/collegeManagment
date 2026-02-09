using cm.api.Context;
using cm.api.Dtos;
using cm.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController: ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO studentDTO)
        {
            if (studentDTO.AcademicRecord == null) return BadRequest("Record can't be empty");

            string matricula = "M-" + DateTime.Now.Year + "" + DateTime.Now.Day + "" + ((await _context.Students.CountAsync()) + 1);
            
            var record = _context.AcademicRecords.Add(new AcademicRecord
            {
                Average = 0.0,
                Carreer = studentDTO.AcademicRecord.Carreer,
                CurrentPeriod = 0,
                Matricula = matricula,
                FacultyId = studentDTO.AcademicRecord.FacultyId,
                State = "Admitido",
                YearEnrrollMent = DateOnly.FromDateTime(DateTime.Now),
            });
            await _context.SaveChangesAsync();

            var student =  _context.Students.Add(new Student
            {
                FirstName = studentDTO.FirstName,
                BirthDate = studentDTO.BirthDate,
                PhoneNumber = studentDTO.PhoneNumber,
                Adress = studentDTO.Adress,
                LastName = studentDTO.LastName,
                Email = studentDTO.Email,
                Gender = studentDTO.Gender,
                Nationality = studentDTO.Nationality,
                RecordId = record.Entity.RecordID,
            });
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _context.Students
                                            .Include(s => s.AcademicRecord)
                                            .ToListAsync();
            return Ok(students);
        }

        [HttpGet("get-with-id/{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _context.Students
                    .Include(s => s.AcademicRecord)
                    .FirstOrDefaultAsync(s => s.StudentID == id);
                                            

            if (student == null) return NoContent();

            return Ok(student);
        }

        [HttpGet("get-with-matricula/{matricula}")]
        public async Task<ActionResult<Student>> GetByMatricula(string matricula)
        {
            var student = await _context.Students
                    .Include(s => s.AcademicRecord)
                    .FirstOrDefaultAsync(s => s.AcademicRecord.Matricula == matricula);


            if (student == null) return NoContent();

            return Ok(student);
        }
        [HttpPut]
        public async Task<ActionResult<Student>> Update(UpdateStudentDTO updateStudentDTO)
        {
            Student? student = await _context.Students.FindAsync(updateStudentDTO.StudentID);
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
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }
        
        [HttpDelete("{matricula}")]
        public async Task<ActionResult<Student>> DeleteByMatricula(string matricula)
        {
            var student = await _context.Students
                    .Include(s => s.AcademicRecord)
                    .FirstOrDefaultAsync(s => s.AcademicRecord.Matricula == matricula);

            if (student == null) return NoContent();
            _context.Students.Remove(student);
            _context.AcademicRecords.Remove(student.AcademicRecord);
            await _context.SaveChangesAsync(); 

            return Ok($"The record matricula {student.AcademicRecord.Matricula} have been removed");
        }
        [HttpGet("records/{matricula}")]
        public async Task<ActionResult<AcademicRecord>> GetRecord(string matricula)
        {
            var record = await _context.AcademicRecords.FirstOrDefaultAsync(r =>r.Matricula == matricula);
                     
            if (record == null) return NoContent();

            return Ok(record);
        }

        [HttpPut("update-status")]
        public async Task<ActionResult<AcademicRecord>> UpdateState(UpdateStateStudentStateDTO update)
        {
            AcademicRecord? record = await _context.AcademicRecords.
                    FirstOrDefaultAsync(r => r.Matricula == update.matricula);
            if (record == null) return NotFound();
            record.State = update.State;
            await _context.SaveChangesAsync();
            return Ok(record);
        }
    }
}
