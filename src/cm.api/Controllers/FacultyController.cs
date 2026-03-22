using cm.api.Dtos;
using cm.api.Dtos.faculty;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/faculty")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        [HttpPost]
        public IActionResult Create(CreateFacultyDTO createFacultyDTO)
        {
            _facultyRepository.Add(new Faculty { Name = createFacultyDTO.Name });
            return StatusCode(201, ApiResponse<Faculty>.SuccessResponse(null, "Created", 201));
        }

        [HttpGet]
        public async Task<ActionResult<List<Faculty>>> GetAll()
        {
            var faculties =  _facultyRepository.GetAll();

            return StatusCode(200, ApiResponse<List<Faculty>>.SuccessResponse(faculties));
        }


    }
}
