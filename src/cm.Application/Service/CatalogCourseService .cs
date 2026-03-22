using cm.Application.Dtos.catalog;
using cm.Application.Interfaces;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;

namespace cm.Application.Services
{
    public class CatalogCourseService : ICatalogCourseService
    {
        private readonly ICatalogCourseRepository _catalogCourseRepository;

        public CatalogCourseService(ICatalogCourseRepository catalogCourseRepository)
        {
            _catalogCourseRepository = catalogCourseRepository;
        }

        public CatalogCourse Create(CreateCatalogDTO dto)
        {
            var catalog = new CatalogCourse
            {
                Code = dto.Code,
                Name = dto.Name,
                Score = dto.Score,
                SubjectId = 0
            };

            return _catalogCourseRepository.Add(catalog);
        }

        public List<CatalogCourse> GetAll()
        {
            return _catalogCourseRepository.GetAll();
        }
    }
}