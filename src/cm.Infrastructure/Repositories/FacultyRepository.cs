
using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;

namespace cm.Infrastructure.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDbContext _context;
        public FacultyRepository(AppDbContext context)
        {
            _context = context;
        }

        public Faculty Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
            return faculty;
        }

        public List<Faculty> GetAll()
        {
            var faculties = _context.Faculties.ToList();
            return faculties;
        }

        public Faculty GetById(int id)
        {
            var faculty = _context.Faculties.Find(id);
            return faculty;
        }

        public Faculty Update(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
            _context.Entry(faculty).Reload();
            return faculty;
        }
    }
}
