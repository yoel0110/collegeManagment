using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;

namespace cm.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Department Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }



        public List<Department> GetAll()
        {
            var departments = _context.Departments.ToList();
            return departments;
        }

        public Department GetById(int id)
        {
            var deparment = _context.Departments.Find(id);
            return deparment;
        }

        public Department Update(Department department) {
            _context.Departments.Update(department);
            _context.SaveChanges();
            _context.Entry(department).Reload();
            return department;
        }
    }
}
