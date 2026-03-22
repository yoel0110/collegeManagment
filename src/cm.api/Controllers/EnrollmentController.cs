using cm.api;
using cm.Application.Contract.cm.Application.Interfaces;
using cm.Application.Dtos.enrollment;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpPost]
    public IActionResult Create(CreateEnrollmentDTO dto)
    {
        try
        {
            var enrollment = _enrollmentService.EnrollStudent(dto);
            return StatusCode(201, ApiResponse<Enrollment>.SuccessResponse(enrollment, "Created", 201));
        }
        catch (KeyNotFoundException ex)
        {
            return StatusCode(404, ApiResponse<Enrollment>.UnSuccessFullResponse(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<Enrollment>.UnSuccessFullResponse(ex.Message));
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var enrollments = _enrollmentService.GetAll();
        return StatusCode(200, ApiResponse<List<Enrollment>>.SuccessResponse(enrollments));
    }
}
