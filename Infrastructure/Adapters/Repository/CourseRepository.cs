using Domain.Entities;
using Domain.Ports.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public Task<List<Course>> GetAssignedCourses(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetcourseByCode(string code)
        {
            return _context.Courses
                    .FirstOrDefaultAsync(course => course.Code.Equals(code));
        }

        public Task<List<Course>> GetCoursesWithoutAssignment(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetWithEnrollmentsAsync(Guid courseId)
        {
            return _context.Courses
                .Include(entity => entity.Enrollments)
                .ThenInclude(entity => entity.Student)
                .FirstOrDefaultAsync(course => course.Id.Equals(courseId));
        }

        public Task<List<Course>> GetWithEnrollmentsAsync()
        {
            return _context.Courses
                .Include(entity => entity.Enrollments)
                .ThenInclude(entity => entity.Student)
                .ToListAsync();
        }
    }
}
