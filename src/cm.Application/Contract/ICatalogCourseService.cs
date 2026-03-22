using cm.Application.Dtos.catalog;
using cm.Domain.Entities;

namespace cm.Application.Interfaces
{
    public interface ICatalogCourseService
    {
        CatalogCourse Create(CreateCatalogDTO dto);
        List<CatalogCourse> GetAll();
    }
}