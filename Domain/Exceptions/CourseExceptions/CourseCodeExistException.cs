namespace Domain.Exceptions.CourseExceptions
{
    public class CourseCodeExistException:Exception
    {
        public CourseCodeExistException()
        {

        }
        public CourseCodeExistException(string mensaje)
        : base(mensaje) { }

        public CourseCodeExistException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
