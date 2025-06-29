namespace Domain.Exceptions.StudentExceptions
{
    public class StudentEmailExistException : Exception
    {
        public StudentEmailExistException()
        {
            
        }
        public StudentEmailExistException(string mensaje)
        : base(mensaje) { }

        public StudentEmailExistException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
