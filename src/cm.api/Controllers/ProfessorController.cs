using cm.Application.Dtos.professor;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using cm.Application.Contract;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/profesor")]
    public class ProfessorController : ControllerBase
    {

        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        public IActionResult Create(CreateProfessorDTO dto)
        {
            var professor = _professorService.CreateProfessor(dto);
            if(professor == null)
            {
                return StatusCode(404, ApiResponse<Professor>.UnSuccessFullResponse(message: "Not foun catalog/department.", statusCode: 404));
            }
            return StatusCode(201, ApiResponse<Professor>.SuccessResponse(professor, statusCode: 201));
        }

        [HttpGet]
        public ActionResult<List<Professor>> GetAll()
        {
            var professors = _professorService.GetProfessors();
            return StatusCode(200, ApiResponse<List<Professor>>.SuccessResponse(professors));
        }

    }
}
