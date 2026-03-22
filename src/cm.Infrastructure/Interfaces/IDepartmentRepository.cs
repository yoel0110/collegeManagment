
using cm.Domain.Entities;

namespace cm.Infrastructure.Interfaces
{
    public interface IDepartmentRepository
    {
        public Department Add(Department department);
        public Department Update(Department department);
        public Department GetById(int id);
        public List<Department> GetAll();
    }
}
