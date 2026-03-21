using cm.Domain.Entities;
namespace cm.Infrastructure.Interfaces
{
    public interface IProfessorRepository
    {
        public Professor Add(Professor professor);
        public Professor Update(Professor professor);
        public Professor GetById(int id);
       // public CatalogCourse GetCatalogCourseById(int id);
        public List<Professor> ListAll();

    }
}
