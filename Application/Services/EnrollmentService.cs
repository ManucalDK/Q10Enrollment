using Domain.Entities;
using Domain.Exceptions.EnrollmentExceptions;
using Domain.Ports.Repository;
using Domain.Ports.Services;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> CanEnrollAsync(Guid stundentId, Guid courseId)
        {
            const int MAX_CREDITS = 4;
            const int MAX_COURSES_WITH_4 = 3;

            var enrollmentTask = _enrollmentRepository.GetEnrollmentCourses(stundentId);
            var courseTask = _courseRepository.GetByIdAsync(courseId);

            await Task.WhenAll(enrollmentTask, courseTask);

            var enrollment = await enrollmentTask;
            var course = await courseTask;

            var enrollmentCourseUpToFour = enrollment.Count(course => course.Course.Credits > MAX_CREDITS);

            return !(course?.Credits > MAX_CREDITS && enrollmentCourseUpToFour >= MAX_COURSES_WITH_4);
        }

        public async Task EnrollAsync(Guid studentId, Guid courseId)
        {
            if(!await CanEnrollAsync(studentId, courseId))
            {
                throw new EnrollmentCreditAmountException(AppMessages.EnrollmentCreditLimitExceptionMessage);
            }

            var assignment = new Enrollment()
            {
                StudentId = studentId,
                CourseId = courseId
            };

            await _enrollmentRepository.AddAsync(assignment);

        }

        public async Task UnassignAsync(Guid studentId, Guid courseId)
        {
            var enroll = await _enrollmentRepository.GetByStudentAndCourse(studentId, courseId);
            if(enroll is not null)
            {
                await _enrollmentRepository.DeleteAsync(enroll.Id);
            }

        }
    }
}
