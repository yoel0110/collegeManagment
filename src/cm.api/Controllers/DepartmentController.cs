 
using cm.api.Dtos.department;
using Microsoft.AspNetCore.Mvc;
using cm.api.Dtos;
using cm.Infrastructure.Interfaces;
using cm.Domain.Entities;
namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public DepartmentController(IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository)
        {
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
        }

        [HttpPost]
        public IActionResult Create(CreateDeparmentDTO createDeparmentDTO)
        {
            var faculty = _facultyRepository.GetById(createDeparmentDTO.FacultyId);

            if (faculty == null)
            {
                return StatusCode(404, ApiResponse<Department>.UnSuccessFullResponse("Not found faculty", 404));
            }

            var department = _departmentRepository.Add(new Department
            {
                Faculty = faculty,
                FacultyId = createDeparmentDTO.FacultyId,
                Name = createDeparmentDTO.Name
            });

            return StatusCode(201, ApiResponse<Department>.SuccessResponse(department,"Created", 201));

        }
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GeAll()
        {
            var deparments = _departmentRepository.GetAll();
            return StatusCode(200, ApiResponse<List<Department>>.SuccessResponse(deparments));
        }
    }
}
