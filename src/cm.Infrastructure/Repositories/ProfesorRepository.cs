
using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cm.Infrastructure.Repositories
{
    public class ProfesorRepository: IProfessorRepository
    {
        private readonly AppDbContext _context;
        private readonly ICatalogCourseRepository _catalogCourseRepository;

        public ProfesorRepository(AppDbContext context, ICatalogCourseRepository catalogCourseRepository)
        {
            _context = context;
            _catalogCourseRepository = catalogCourseRepository;
        }

        public Professor Add(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
            return professor;
        }

        public Professor GetById(int id)
        {
            var profesor = _context.Professors
                                .Include(p => p.CatalogCourse)
                                .FirstOrDefault(p => p.ProfessorID == id);
            return profesor;
        }


        public List<Professor> ListAll()
        {
            var profesors = _context.Professors
                                .Include(p => p.CatalogCourse)
                                .ToList();
            return profesors;
        }

        public Professor Update(Professor professor)
        {
            _context.Professors.Update(professor);
            _context.SaveChanges();
            _context.Entry(professor).Reload();
            return professor;
        }
    }
}
