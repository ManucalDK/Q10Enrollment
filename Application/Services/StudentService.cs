using Domain.Entities;
using Domain.Ports.Repository;
using Domain.Ports.Services;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<Student>> GetStudents()
        {
            var studentList = await _studentRepository.GetWithEnrollmentsAsync();

            return await Task.FromResult(studentList);
        }
    }
}
