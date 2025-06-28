using Domain.Entities;

namespace Domain.Ports.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
    }
}
