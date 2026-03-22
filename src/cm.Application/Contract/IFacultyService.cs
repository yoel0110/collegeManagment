

using cm.Application.Dtos.faculty;
using cm.Domain.Entities;

namespace cm.Application.Contract
{
    public interface IFacultyService
    {
        Faculty Create(CreateFacultyDTO createFacultyDTO);
        List<Faculty> GetAll();
    }
}
