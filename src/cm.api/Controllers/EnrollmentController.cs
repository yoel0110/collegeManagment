using cm.api.Dtos.enrollment;
using cm.api.Dtos;
using cm.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cm.Infrastructure.Interfaces;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/enrollment")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IAcedemicRecordRepository _acedemicRecordRepository;
        private readonly ICatalogCourseRepository _catalogCourseRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository, 
            IAcedemicRecordRepository acedemicRecordRepository,
            ICatalogCourseRepository catalogCourseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _acedemicRecordRepository = acedemicRecordRepository;
            _catalogCourseRepository = catalogCourseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollmentDTO dto)
        {

            var record = _acedemicRecordRepository.GetById(dto.RecordID);
            if (record == null)
                return StatusCode(403, ApiResponse<Enrollment>.SuccessResponse(null, "Record not found."));

            var catalog = _catalogCourseRepository.getById(dto.SubjectId);
            if (catalog == null)
                return StatusCode(403, ApiResponse<Enrollment>.SuccessResponse(null, "Catalog not found."));

            _enrollmentRepository.Add(new Enrollment
            {
                EnrollDate = dto.EnrollDate,
                RecordID = dto.RecordID,
                SubjectId = dto.SubjectId,
                Status = dto.Status,

            });
            return StatusCode(200, ApiResponse<Enrollment>.SuccessResponse(null, "Created"));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var enrollments = _enrollmentRepository.ListAll();
            return Ok(ApiResponse<List<Enrollment>>.SuccessResponse(enrollments));
        }
    }
}
