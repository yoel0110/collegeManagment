using cm.api.Context;
using cm.api.Dtos.professor;
using cm.api.Dtos;
using cm.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/profesor")]
    public class ProfessorController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ProfessorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProfessorDTO dto)
        {
            var department = await _context.Departments.FindAsync(dto.DepartmentId);
            var catalog = await _context.CatalogCourses.FindAsync(dto.CatalogId);

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

            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            //_context.Professors.Add);

            return StatusCode(201,ApiResponse<Professor>.SuccessResponse(professor, statusCode: 201));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfessorDto>>> GetAll()
        {
            var professors = await _context.Professors
                                        .Include(p => p.CatalogCourse)
                                        .Select(p => new ProfessorDto
                                        {
                                            Id = p.ProfessorID,
                                            FullName = p.FirstName + ' '+ p.LastName,
                                            CourseName = p.CatalogCourse.Name
                                        })
                                        .ToListAsync();

            return StatusCode(200, ApiResponse<List<ProfessorDto>>.SuccessResponse(professors));
        }

    }
}
