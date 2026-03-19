using cm.api.Context;
using cm.api.Dtos;
using cm.api.Dtos.faculty;
using cm.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/faculty")]
    public class FacultyController: ControllerBase
    {
        private readonly AppDbContext _context;

        public FacultyController(AppDbContext context)
        {
            _context = context;    
        }

        [HttpPost]
        public IActionResult Create(CreateFacultyDTO createFacultyDTO)
        {
            _context.Faculties.Add(new Faculty { Name = createFacultyDTO.Name });
            _context.SaveChangesAsync();
            return StatusCode(201, ApiResponse<Faculty>.SuccessResponse(null, "Created", 201));
        }

        [HttpGet]
        public async Task<ActionResult<List<Faculty>>> GetAll()
        {
            var faculties = await _context.Faculties.ToListAsync();
            
            return StatusCode(200, ApiResponse<List<Faculty>>.SuccessResponse(faculties));
        }


    }
}
