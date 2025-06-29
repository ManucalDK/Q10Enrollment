namespace Test.HelperTest
{
    using Domain.Helpers;
    public class ArgumentValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void NullOrWhiteSpace_InvalidInput_ThrowsArgumentNullException(string input)
        {
            var message = "Input cannot be null or whitespace";

            var ex = Assert.Throws<ArgumentNullException>(() =>
                ArgumentValidator.NullOrWhiteSpace(input, message));

            Assert.Equal(message, ex.ParamName);
        }

        [Fact]
        public void NullOrWhiteSpace_ValidInput_DoesNotThrow()
        {
            var input = "Valid String";
            var message = "Should not throw";

            var exception = Record.Exception(() =>
                ArgumentValidator.NullOrWhiteSpace(input, message));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(5, 1, 10)]
        [InlineData(1, 1, 10)]
        [InlineData(10, 1, 10)]
        public void ValueOutOfRange_ValidValue_DoesNotThrow(int value, int min, int max)
        {
            var exception = Record.Exception(() =>
                ArgumentValidator.ValueOutOfRange(value, min, max, "Should not throw"));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(0, 1, 10)]
        [InlineData(11, 1, 10)]
        public void ValueOutOfRange_InvalidValue_ThrowsArgumentOutOfRangeException(int value, int min, int max)
        {
            var message = "Value is out of range";

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
                ArgumentValidator.ValueOutOfRange(value, min, max, message));

            Assert.Equal(message, ex.ParamName);
        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(10, 9)]
        public void ValueMin_ValidValue_DoesNotThrow(int value, int min)
        {
            var exception = Record.Exception(() =>
                ArgumentValidator.ValueMin(value, min, "Should not throw"));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData(2, 3)]
        public void ValueMin_InvalidValue_ThrowsArgumentException(int value, int min)
        {
            var message = "Value is below minimum";

            var ex = Assert.Throws<ArgumentException>(() =>
                ArgumentValidator.ValueMin(value, min, message));

            Assert.Equal(message, ex.Message);
        }

        [Theory]
        [InlineData("test@example.com")]
        [InlineData("user.name+tag+sorting@example.com")]
        public void EmailFormat_ValidEmail_DoesNotThrow(string email)
        {
            var exception = Record.Exception(() =>
                ArgumentValidator.EmailFormat(email, "Should not throw"));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData("not-an-email")]
        [InlineData("missingdomain.com")]
        [InlineData("user@.com")]
        public void EmailFormat_InvalidEmail_ThrowsArgumentException(string email)
        {
            var message = "Invalid email format";

            var ex = Assert.Throws<ArgumentException>(() =>
                ArgumentValidator.EmailFormat(email, message));

            Assert.Equal(message, ex.Message);
        }
    }
}
