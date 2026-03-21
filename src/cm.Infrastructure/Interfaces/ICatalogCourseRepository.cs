
using cm.Domain.Entities;

namespace cm.Infrastructure.Interfaces
{
    public interface ICatalogCourseRepository
    {
        public CatalogCourse Add(CatalogCourse catalogCourse);
        public CatalogCourse Update(CatalogCourse catalogCourse);
        public List<CatalogCourse> GetAll();
    }
}
