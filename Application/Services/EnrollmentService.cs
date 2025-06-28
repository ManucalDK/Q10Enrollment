using Domain.Ports.Services;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        public Task<bool> CanEnrollAsync(Guid stundentId, Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task EnrollAsync(Guid studentId, Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
