using cm.Domain.Entities;
using cm.Infrastructure.Context;
using cm.Infrastructure.Interfaces;

namespace cm.Infrastructure.Repositories
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Enrollment Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return enrollment;
        }

        public Enrollment Delete(Enrollment enrollment)
        {
            enrollment.Status = "Canceled";
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return enrollment;
        }

        public Enrollment GetById(int enrollmentId)
        {
            var enrollment = _context.Enrollments.Find(enrollmentId);
            return enrollment;
        }

        public List<Enrollment> ListAll()
        {
            var enrollments = _context.Enrollments
                .ToList();
            return enrollments;
        }

        public Enrollment Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            _context.Entry(enrollment).Reload();
            return enrollment;
        }
    }
}
