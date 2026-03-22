using cm.Application.Contract;
using cm.Application.Dtos.professor;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;
using cm.Infrastructure.Repositories;
 
namespace cm.Application.Service
{
    public class ProfessorService: IProfessorService
    {
        private readonly IProfessorRepository _profesorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly ICatalogCourseRepository _catalogCourseRepository;
        public ProfessorService(IProfessorRepository profesorRepository,
            IDepartmentRepository departmentRepository,
            IFacultyRepository facultyRepository, ICatalogCourseRepository catalogCourseRepository)
        {
            _profesorRepository = profesorRepository;
            _departmentRepository = departmentRepository;
            _facultyRepository = facultyRepository;
            _catalogCourseRepository = catalogCourseRepository;
        }

        public Professor CreateProfessor(CreateProfessorDTO dto)
        {
            var department = _departmentRepository.GetById(dto.DepartmentId);
            var catalog = _catalogCourseRepository.getById(dto.CatalogId);

            if (department == null)
            {
                return null;  
            }
            if (catalog == null)
            {
                return null;  
            }
            var professor = new Professor
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Specialty = dto.Specialty,
                Status = dto.Status,
                DepartmentId = dto.DepartmentId,
                CatalogCourse = new List<CatalogCourse> { catalog }
            };

            professor = _profesorRepository.Add(professor);
            return professor;
        }

        public Professor GetProfessor(int id)
        {
            return _profesorRepository.GetById(id);
        }

        public List<Professor> GetProfessors()
        {
            var professors = _profesorRepository.ListAll();
            return professors;
        }

        public Professor UpdateProfessor(UpdateProfessorDTO updateProfessorDTO)
        {   //todo
            throw new NotImplementedException();
        }
    }
}
