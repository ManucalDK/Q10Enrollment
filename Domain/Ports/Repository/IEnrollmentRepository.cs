using Domain.Entities;

namespace Domain.Ports.Repository
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<Enrollment?> GetByStudentAndCourse(Guid studentId, Guid courseId);
        Task<List<Enrollment>> GetEnrollmentCourses(Guid studentId);
    }
}
