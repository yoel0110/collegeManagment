using cm.Application.Contract;
using cm.Application.Dtos.department;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;

namespace cm.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, IFacultyRepository facultyRepository)
        {
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
        }

        public Department Create(CreateDeparmentDTO dto)
        {
            var faculty = _facultyRepository.GetById(dto.FacultyId);
            if (faculty == null)
                throw new KeyNotFoundException("Faculty not found.");

            return _departmentRepository.Add(new Department
            {
                FacultyId = dto.FacultyId,
                Name = dto.Name
            });
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}