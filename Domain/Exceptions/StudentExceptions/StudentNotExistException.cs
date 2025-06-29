namespace Domain.Exceptions.StudentExceptions
{
    public class StudentNotExistException : Exception
    {
        public StudentNotExistException()
        {

        }
        public StudentNotExistException(string mensaje)
        : base(mensaje) { }

        public StudentNotExistException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
