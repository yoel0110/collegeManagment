using cm.Application.Contract;
using cm.Application.Dtos.faculty;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/faculty")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpPost]
        public IActionResult Create(CreateFacultyDTO createFacultyDTO)
        {
            _facultyService.Create(createFacultyDTO);
            return StatusCode(201, ApiResponse<Faculty>.SuccessResponse(null, "Created", 201));
        }

        [HttpGet]
        public ActionResult<List<Faculty>> GetAll()
        {
            var faculties = _facultyService.GetAll();
            return StatusCode(200, ApiResponse<List<Faculty>>.SuccessResponse(faculties));
        }
    }
}
