using Domain.Dtos;
using Domain.Entities;

namespace Domain.Ports.Services
{
    public interface ICourseService
    {
        Task AddCourse(AddCourseDto newCourse);
        Task DeleteCourse(Guid id);
        Task<List<Course>> GetAssignedCourses(Guid studentId);
        Task<Course> GetCourseById(Guid id);
        Task<List<Course>> GetCourses();
        Task<List<Course>> GetCoursesWithoutAssignment(Guid studentId);
        Task UpdateCourse(Guid id, AddCourseDto newCourse);
    }
}
