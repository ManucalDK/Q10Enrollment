using Domain.Helpers;

namespace Domain.Entities
{
    public class Course: DefaultEntity
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public static readonly int MIN_CREDIT = 0;

        public Course(string name, int credits)
        {

            ArgumentValidator.NullOrWhiteSpace(name, string.Format(DomainMessages.ArgStringNull, nameof(Name)));
            ArgumentValidator.ValueMin(credits, MIN_CREDIT, string.Format(DomainMessages.ArgOutOfRange, nameof(Credits), MIN_CREDIT));

            Name = name;
            Credits = credits;
        }
    }
}

