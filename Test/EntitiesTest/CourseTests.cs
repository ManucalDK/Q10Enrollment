using Domain;
using Domain.Entities;
using System.Xml.Linq;

namespace Test.EntitiesTest
{
    public class CourseTests
    {
        [Fact]
        public void Constructor_ValidArguments_ShouldCreateCourse()
        {
            string name = "Mathematics";
            string code = "MATH101";
            int credits = 3;

            var course = new Course(name, code, credits);

            Assert.Equal(name, course.Name);
            Assert.Equal(code, course.Code);
            Assert.Equal(credits, course.Credits);
            Assert.Empty(course.Enrollments);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_InvalidName_ThrowsArgumentNullException(string name)
        {
            var message = string.Format(DomainMessages.ArgStringNull, nameof(Course.Name));
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Course(name, "CODE123", 3));

            Assert.Equal(message, ex.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_InvalidCode_ThrowsArgumentNullException(string code)
        {
            var message = string.Format(DomainMessages.ArgStringNull, nameof(Course.Code));

            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Course("Valid Name", code, 3));

            Assert.Equal(message, ex.ParamName);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Constructor_InvalidCredits_ThrowsArgumentException(int credits)
        {
            var message = string.Format(DomainMessages.ArgGreaterThan, nameof(Course.Credits), Course.MIN_CREDIT);

            var ex = Assert.Throws<ArgumentException>(() =>
                new Course("Valid Name", "CODE123", credits));

            Assert.Contains(message, ex.Message);
        }

        [Fact]
        public void UpdateValues_ValidInput_UpdatesCourse()
        {
            
            var course = new Course("Old Name", "OLD123", 2);
            string newName = "New Name";
            string newCode = "NEW456";
            int newCredits = 5;

            course.UpdateValues(newName, newCode, newCredits);

            Assert.Equal(newName, course.Name);
            Assert.Equal(newCode, course.Code);
            Assert.Equal(newCredits, course.Credits);
        }

        [Fact]
        public void UpdateValues_InvalidName_ThrowsArgumentNullException()
        {
            var message = string.Format(DomainMessages.ArgStringNull, nameof(Course.Name));
            var course = new Course("Name", "CODE", 3);

            var ex = Assert.Throws<ArgumentNullException>(() =>
                course.UpdateValues(null, "CODE", 3));

            Assert.Equal(message, ex.ParamName);
        }

        [Fact]
        public void UpdateValues_InvalidCode_ThrowsArgumentNullException()
        {
            var message = string.Format(DomainMessages.ArgStringNull, nameof(Course.Code));
            var course = new Course("Name", "CODE", 3);

            var ex = Assert.Throws<ArgumentNullException>(() =>
                course.UpdateValues("Name", null, 3));

            Assert.Equal(message, ex.ParamName);
        }

        [Fact]
        public void UpdateValues_InvalidCredits_ThrowsArgumentException()
        {
            var message = string.Format(DomainMessages.ArgGreaterThan, nameof(Course.Credits), Course.MIN_CREDIT);
            var course = new Course("Name", "CODE", 3);

            var ex = Assert.Throws<ArgumentException>(() =>
                course.UpdateValues("Name", "CODE", -1));

            Assert.Contains(message, ex.Message);
        }
    }
}
