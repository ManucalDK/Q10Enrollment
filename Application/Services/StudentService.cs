using Domain.Dtos;
using Domain.Entities;
using Domain.Exceptions.StudentExceptions;
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

        public async Task AddStudent(AddStudentDto newStudent)
        {
            var existEmail = await _studentRepository.GetStudentByEmail(newStudent.Email);

            if (existEmail is not null)
            {
                throw new StudentEmailExistException(string.Format(AppMessages.ExistEmailExceptionMessage, newStudent.Email));
            }

            Student student = new(name: newStudent.Name, document: newStudent.Document, email: newStudent.Email);
            await _studentRepository.AddAsync(student);
        }

        public async Task<List<Student>> GetStudents()
        {
            var studentList = await _studentRepository.GetWithEnrollmentsAsync();

            return studentList.OrderBy(student => student.Name)
                .ToList();
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null)
            {
                throw new StudentNotExistException(string.Format(AppMessages.StudentNotExistExceptionMessage, id.ToString()));
            }
            return student;
        }

        public async Task UpdateStudent(Guid id, AddStudentDto student)
        {
            var updateStudent = await _studentRepository.GetStudentByEmail(student.Email);

            if (updateStudent is not null && !id.Equals(updateStudent.Id))
            {
                throw new StudentEmailExistException(string.Format(AppMessages.ExistEmailExceptionMessage, student.Email));
            }

            updateStudent = await _studentRepository.GetByIdAsync(id);
            if (updateStudent is null)
            {
                throw new StudentNotExistException(string.Format(AppMessages.StudentNotExistExceptionMessage, id.ToString()));
            }

            updateStudent.UpdateValues(name: student.Name, document: student.Document, email: student.Email);

            await _studentRepository.UpdateAsync(updateStudent);
        }

        public async Task DeleteStudent(Guid id)
        {
            var updateStudent = await _studentRepository.GetByIdAsync(id);
            if (updateStudent is null)
            {
                throw new StudentNotExistException(string.Format(AppMessages.StudentNotExistExceptionMessage, id.ToString()));
            }
            await _studentRepository.DeleteAsync(id);
        }
    }
}
