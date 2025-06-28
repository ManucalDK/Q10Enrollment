using Domain.Entities;
using Domain.Ports.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Adapters.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Student?> GetWithEnrollmentsAsync(Guid studentId)
        {
            return _context.Students
                .Include(entity => entity.Enrollments)
                .ThenInclude(entity => entity.Course)
                .FirstOrDefaultAsync(student => student.Id == studentId);
        }
    }
}
