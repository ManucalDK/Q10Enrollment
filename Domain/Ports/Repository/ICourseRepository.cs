using Domain.Entities;

namespace Domain.Ports.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course?> GetcourseByCode(string code);
        Task<Course?> GetWithEnrollmentsAsync(Guid courseId);
        Task<List<Course>> GetWithEnrollmentsAsync();
    }
}
