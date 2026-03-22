using cm.Domain.Entities;

namespace cm.Infrastructure.Interfaces
{
    public interface IFacultyRepository
    {
        public Faculty Add(Faculty faculty);
        public Faculty Update(Faculty faculty);
        public Faculty GetById(int id);
        public List<Faculty> GetAll();
    }
}
