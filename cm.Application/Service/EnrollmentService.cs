using cm.Application.Contract.cm.Application.Interfaces;
using cm.Application.Dtos.enrollment;
using cm.Domain.Entities;
using cm.Infrastructure.Interfaces;

namespace cm.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IAcedemicRecordRepository _acedemicRecordRepository;
        private readonly ICatalogCourseRepository _catalogCourseRepository;

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository,
            IAcedemicRecordRepository acedemicRecordRepository,
            ICatalogCourseRepository catalogCourseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _acedemicRecordRepository = acedemicRecordRepository;
            _catalogCourseRepository = catalogCourseRepository;
        }

        public Enrollment EnrollStudent(CreateEnrollmentDTO dto)
        {
            var record = _acedemicRecordRepository.GetById(dto.RecordID);
            if (record == null)
                throw new KeyNotFoundException("Record not found.");

            var catalog = _catalogCourseRepository.getById(dto.SubjectId);
            if (catalog == null)
                throw new KeyNotFoundException("Catalog not found.");

            return _enrollmentRepository.Add(new Enrollment
            {
                EnrollDate = dto.EnrollDate,
                RecordID = dto.RecordID,
                SubjectId = dto.SubjectId,
                Status = dto.Status,
            });
        }

        public List<Enrollment> GetAll()
        {
            return _enrollmentRepository.ListAll();
        }
    }
}