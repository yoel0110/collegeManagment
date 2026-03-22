using cm.Application.Dtos.catalog;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using cm.api;
namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogCourseRepository _catalogCourseRepository;

        public CatalogController(ICatalogCourseRepository catalogCourseRepository)
        {
            _catalogCourseRepository = catalogCourseRepository;
        }

        [HttpPost]
        public IActionResult Create(CreateCatalogDTO dto)
        {
            var catalog = new CatalogCourse
            {
                Code = dto.Code,
                Name = dto.Name,
                Score = dto.Score,
                SubjectId = 0
            };

           catalog = _catalogCourseRepository.Add(catalog);
            return Ok(ApiResponse<CatalogCourse>.SuccessResponse(catalog, "Created"));
        }

        [HttpGet]
        public ActionResult<List<CatalogCourse>> GetAll()
        {
            var catalog = _catalogCourseRepository.GetAll();
            return Ok(ApiResponse<List<CatalogCourse>>.SuccessResponse(catalog));
        }
    }
}
