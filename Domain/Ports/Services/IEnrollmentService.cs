namespace Domain.Ports.Services
{
    public interface IEnrollmentService
    {
        Task<bool> CanEnrollAsync(Guid stundentId, Guid courseId);
        Task EnrollAsync(Guid studentId, Guid courseId);
        Task UnassignAsync(Guid studentId, Guid courseId);
    }
}
