using Domain.Entities;

namespace Domain.Ports.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task <List<Course>>GetAssignedCourses(Guid studentId);
        Task<List<Course>> GetCoursesWithoutAssignment(Guid studentId);
        Task<Course?> GetcourseByCode(string code);
        Task<Course?> GetWithEnrollmentsAsync(Guid courseId);
        Task<List<Course>> GetWithEnrollmentsAsync();
    }
}
