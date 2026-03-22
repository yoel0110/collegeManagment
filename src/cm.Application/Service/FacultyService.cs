
using cm.Application.Contract;
using cm.Application.Dtos.faculty;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;

namespace cm.Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public Faculty Create(CreateFacultyDTO createFacultyDTO)
        {
            var faculty = new Faculty { Name = createFacultyDTO.Name };
            return _facultyRepository.Add(faculty);
        }

        public List<Faculty> GetAll()
        {
            return _facultyRepository.GetAll();
        }
    }
}
