namespace Domain.Exceptions.EnrollmentExceptions
{
    public class EnrollmentCreditAmountException : Exception
    {
        public EnrollmentCreditAmountException()
        {

        }
        public EnrollmentCreditAmountException(string mensaje)
        : base(mensaje) { }

        public EnrollmentCreditAmountException(string mensaje, Exception inner)
            : base(mensaje, inner) { }
    }
}
