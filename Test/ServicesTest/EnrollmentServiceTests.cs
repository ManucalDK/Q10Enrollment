using Application.Services;
using Domain.Entities;
using Domain.Ports.Repository;
using NSubstitute;

namespace Test.ServicesTest
{
    public class EnrollmentServiceTests
    {
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly EnrollmentService _enrollmentService;

        public EnrollmentServiceTests()
        {
            _enrollmentRepo = Substitute.For<IEnrollmentRepository>();
            _courseRepo = Substitute.For<ICourseRepository>();
            _enrollmentService = new EnrollmentService(_enrollmentRepo, _courseRepo);
        }

        [Fact]
        public async Task CanEnrollAsync_ReturnsTrue_WhenCourseCreditIsFourOrLess()
        {
            
            var studentId = Guid.NewGuid();
            var courseId = Guid.NewGuid();

            var courseResponse = new Course(name: "name", code: "code", credits: 4);

            _enrollmentRepo.GetEnrollmentCourses(studentId)
                           .Returns(Task.FromResult(new List<Enrollment>()));

            _courseRepo.GetByIdAsync(courseId)
                       .Returns(courseResponse);

            
            var canEnroll = await _enrollmentService.CanEnrollAsync(studentId, courseId);

            Assert.True(canEnroll);
        }
    }
}
