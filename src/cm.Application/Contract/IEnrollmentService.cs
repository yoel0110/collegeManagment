using cm.Application.Dtos.enrollment;
using cm.Domain.Entities;
namespace cm.Application.Contract
{
    namespace cm.Application.Interfaces
    {
        public interface IEnrollmentService
        {
            Enrollment EnrollStudent(CreateEnrollmentDTO dto);
            List<Enrollment> GetAll();
        }
    }
}
