
using cm.Domain.Entities;

namespace cm.Infrastructure.Interfaces
{
    public interface IDepartmentRepository
    {
        public Department Add(Department department);
        public Department Update(Department department);

        public List<Department> GetAll();
    }
}
