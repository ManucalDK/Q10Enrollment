using Domain.Dtos;
using Domain.Entities;

namespace Domain.Ports.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task AddStudent(AddStudentDto newStudent);
        Task<Student> GetStudentById(Guid id);
        Task UpdateStudent(Guid id, AddStudentDto student);
        Task DeleteStudent(Guid id);
    }
}
