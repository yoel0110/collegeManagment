using cm.api.Context;
using cm.api.Dtos.enrollment;
using cm.api.Dtos;
using cm.api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/enrollment")]
    public class EnrollmentController: ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollmentDTO dto)
        {

            var record = await _context.AcademicRecords.FindAsync(dto.RecordID);
            if (record == null)
                return StatusCode(403, ApiResponse<Enrollment>.SuccessResponse(null, "Record not found."));

            var catalog = await _context.CatalogCourses.FindAsync(dto.SubjectId);
            if(catalog == null)
                return StatusCode(403, ApiResponse<Enrollment>.SuccessResponse(null, "Catalog not found."));

            _context.Enrollments.Add(new Enrollment
            {
                EnrollDate = dto.EnrollDate,
                RecordID = dto.RecordID,
                SubjectId = dto.SubjectId,
                Status = dto.Status,
                AcademicRecord = record,
                CatalogCourse = catalog

            });
            await _context.SaveChangesAsync();
            return StatusCode(200, ApiResponse<Enrollment>.SuccessResponse(null, "Created"));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.AcademicRecord)
                .Include(e => e.CatalogCourse)
                .ToListAsync();
            return Ok(ApiResponse<List<Enrollment>>.SuccessResponse(enrollments));
        }
    }
}
