using cm.api.Dtos.professor;
using cm.api.Dtos;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cm.Infrastructure.Interfaces;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/profesor")]
    public class ProfessorController : ControllerBase
    {

        private readonly IProfessorRepository _profesorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly ICatalogCourseRepository _catalogCourseRepository;

        public ProfessorController(IProfessorRepository profesorRepository, 
            IDepartmentRepository departmentRepository, 
            IFacultyRepository facultyRepository, ICatalogCourseRepository catalogCourseRepository)
        {
            _profesorRepository = profesorRepository;
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
            _catalogCourseRepository = catalogCourseRepository;
        }

        [HttpPost]
        public IActionResult Create(CreateProfessorDTO dto)
        {
            var department = _departmentRepository.GetById(dto.DepartmentId);
            var catalog = _catalogCourseRepository.getById(dto.CatalogId);

            if (department == null && catalog == null)
            {
                return StatusCode(404, ApiResponse<Professor>.UnSuccessFullResponse(message: "Deparment not found.\nCatalog not found."));
            }

            var professor = new Professor
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Specialty = dto.Specialty,
                Status = dto.Status,
                Department = department,
                CatalogCourse = catalog
            };

            professor = _profesorRepository.Add(professor);
            return StatusCode(201, ApiResponse<Professor>.SuccessResponse(professor, statusCode: 201));
        }

        [HttpGet]
        public ActionResult<List<Professor>> GetAll()
        {
            var professors = _profesorRepository.ListAll();
            return StatusCode(200, ApiResponse<List<Professor>>.SuccessResponse(professors));
        }

    }
}
