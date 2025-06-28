using Domain.Helpers;

namespace Domain.Entities
{
    public class Course : DefaultEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public int Credits { get; private set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public static readonly int MIN_CREDIT = 0;

        public Course(string name, string code, int credits)
        {
            Validate(name, code, credits);

            Name = name;
            Code = code;
            Credits = credits;
        }

        private static void Validate(string name, string code, int credits)
        {
            ArgumentValidator.NullOrWhiteSpace(name, string.Format(DomainMessages.ArgStringNull, nameof(Name)));
            ArgumentValidator.NullOrWhiteSpace(code, string.Format(DomainMessages.ArgStringNull, nameof(Code)));
            ArgumentValidator.ValueMin(credits, MIN_CREDIT, string.Format(DomainMessages.ArgGreaterThan, nameof(Credits), MIN_CREDIT));
        }

        public void UpdateValues(string name, string code, int credits)
        {
            Validate(name, code, credits);

            Name = name;
            Code = code;
            Credits = credits;
        }
    }
}

