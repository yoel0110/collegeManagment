
using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;
using System.Diagnostics;

namespace cm.Infrastructure.Repositories
{
    public class CatalogCourseRepository : ICatalogCourseRepository
    {
        private readonly AppDbContext _context;

        public CatalogCourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public CatalogCourse Add(CatalogCourse catalogCourse)
        {
            _context.CatalogCourses.Add(catalogCourse);
            _context.SaveChanges();
            return catalogCourse;
        }

        public List<CatalogCourse> GetAll()
        {
            var catalogs = _context.CatalogCourses.ToList();
            return catalogs;
        }

        public CatalogCourse getById(int id)
        {
            var catalog = _context.CatalogCourses.Find(id);
            if (catalog == null) return null;
            return catalog;
        }

        public CatalogCourse Update(CatalogCourse catalogCourse)
        {
            _context.Update(catalogCourse);
            _context.SaveChanges();
            _context.Entry(catalogCourse).Reload();
            return catalogCourse;
        }
    }
}
