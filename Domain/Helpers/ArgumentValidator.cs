namespace Domain.Helpers
{
    public static class ArgumentValidator
    {
        public static void NullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValueOutOfRange<T>(T value, T minValue, T maxValue, string message) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0 || value.CompareTo(maxValue) > 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ValueMin<T>(T value, T minValue, string message) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) <= 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void EmailFormat(string value, string message)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                if(addr.Address != value)
                {
                    throw new ArgumentException(message);
                }
            }
            catch
            {
                throw new ArgumentException(message);
            }
        }
    }
}
