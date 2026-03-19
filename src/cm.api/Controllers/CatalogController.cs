using cm.api.Context;
using cm.api.Dtos;
using cm.api.Dtos.catalog;
using cm.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CatalogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCatalogDTO dto)
        {
            var catalog = new CatalogCourse
            {
                Code = dto.Code,
                Name = dto.Name,
                Score = dto.Score,
                SubjectId = 0
            };

            _context.CatalogCourses.Add(catalog);

            await _context.SaveChangesAsync();

            return Ok(ApiResponse<CatalogCourse>.SuccessResponse(catalog, "Created"));
        }

        [HttpGet]
        public async Task<ActionResult<List<CatalogCourse>>> GetAll()
        {
            var catalog = await _context.CatalogCourses.ToListAsync();

            return Ok(ApiResponse<List<CatalogCourse>>.SuccessResponse(catalog));
        }

    }


}
