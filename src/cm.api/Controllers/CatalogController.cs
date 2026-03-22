using cm.Application.Dtos.catalog;
using cm.Application.Interfaces;
using cm.Domain.Entities;
using cm.api;
using Microsoft.AspNetCore.Mvc;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogCourseService _catalogCourseService;

        public CatalogController(ICatalogCourseService catalogCourseService)
        {
            _catalogCourseService = catalogCourseService;
        }

        [HttpPost]
        public IActionResult Create(CreateCatalogDTO dto)
        {
            try
            {
                var catalog = _catalogCourseService.Create(dto);
                return StatusCode(201, ApiResponse<CatalogCourse>.SuccessResponse(catalog, "Created", 201));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<CatalogCourse>.UnSuccessFullResponse(ex.Message));
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var catalog = _catalogCourseService.GetAll();
            return StatusCode(200, ApiResponse<List<CatalogCourse>>.SuccessResponse(catalog));
        }
    }
}