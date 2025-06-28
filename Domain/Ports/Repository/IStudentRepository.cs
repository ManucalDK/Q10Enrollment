using Domain.Entities;

namespace Domain.Ports.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetWithEnrollmentsAsync(Guid studentId);
        Task<List<Student>> GetWithEnrollmentsAsync();
        Task<Student?> GetStudentByEmail(string email);
    }
}
