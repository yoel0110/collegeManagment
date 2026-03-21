using cm.Domain.Entities;

namespace cm.Infrastructure.Interfaces
{
    public interface IEnrollmentRepository
    {
        public Enrollment Add(Enrollment enrollment);
        public Enrollment Update(Enrollment enrollment);
        public Enrollment Delete(Enrollment enrollment);
        public Enrollment GetById(int enrollmentId);
        public List<Enrollment> ListAll();
    }
}
