using cm.api.Context;
using cm.api.Models;
using cm.api.Dtos.department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cm.api.Dtos;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/department")]
    public class DepartmentController: ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeparmentDTO createDeparmentDTO)
        {
            var faculty = await _context.Faculties.FindAsync(createDeparmentDTO.FacultyId);

            if (faculty == null)
            {
                return StatusCode(404, ApiResponse<Department>.UnSuccessFullResponse("Not found", 404));
            }
            
            _context.Departments.Add(new Department { 
                Faculty = faculty,
                FacultyId = createDeparmentDTO.FacultyId,
                Name = createDeparmentDTO.Name
            });

           await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GeAll()
        {
            var deparments = await _context.Departments.ToListAsync();
            return StatusCode(200, ApiResponse<List<Department>>.SuccessResponse(deparments));
        }
    }
}
