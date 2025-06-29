using Domain.Entities;
using Domain.Ports.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Enrollment?> GetByStudentAndCourse(Guid studentId, Guid courseId)
        {
            return await _context.Enrollments
                .Where(enrollemtn => enrollemtn.StudentId.Equals(studentId) && enrollemtn.CourseId.Equals(courseId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Enrollment>> GetEnrollmentCourses(Guid studentId)
        {
            return await _context.Enrollments
                .Include(entity => entity.Course)
                .Where(student => student.StudentId.Equals(studentId))
                .ToListAsync();
        }
    }
}
