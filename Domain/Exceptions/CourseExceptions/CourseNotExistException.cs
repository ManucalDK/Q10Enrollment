namespace Domain.Exceptions.CourseExceptions
{
    public class CourseNotExistException : Exception
    {
        public CourseNotExistException()
        {

        }
        public CourseNotExistException(string mensaje)
        : base(mensaje) { }

        public CourseNotExistException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
