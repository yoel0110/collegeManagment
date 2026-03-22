using cm.Application.Contract;
using cm.Application.Dtos.department;
using cm.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cm.api.Controllers
{
    [ApiController]
    [Route("api/v1/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public IActionResult Create(CreateDeparmentDTO dto)
        {
            try
            {
                var department = _departmentService.Create(dto);
                return StatusCode(201, ApiResponse<Department>.SuccessResponse(department, "Created", 201));
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(404, ApiResponse<Department>.UnSuccessFullResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Department>.UnSuccessFullResponse(ex.Message));
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            return StatusCode(200, ApiResponse<List<Department>>.SuccessResponse(departments));
        }
    }
}