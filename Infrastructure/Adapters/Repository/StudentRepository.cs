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

        public Task<Student?> GetStudentByEmail(string email)
        {
            return _context.Students
                    .FirstOrDefaultAsync(student => student.Email.Equals(email));
        }

        public Task<Student?> GetWithEnrollmentsAsync(Guid studentId)
        {
            return _context.Students
                .Include(entity => entity.Enrollments)
                .ThenInclude(entity => entity.Course)
                .FirstOrDefaultAsync(student => student.Id.Equals(studentId));
        }

        public Task<List<Student>> GetWithEnrollmentsAsync()
        {
            return _context.Students
                .Include(entity => entity.Enrollments)
                .ThenInclude(entity => entity.Course)
                .ToListAsync();
        }
    }
}
