using cm.Application.Dtos.department;
using cm.Domain.Entities;

namespace cm.Application.Contract
{
    public interface IDepartmentService
    {
        Department Create(CreateDeparmentDTO dto);
        List<Department> GetAll();
    }
}