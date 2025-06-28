using Domain.Helpers;

namespace Domain.Entities
{
    public class Student : DefaultEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public Student(string name, string document, string email)
        {
            ArgumentValidator.NullOrWhiteSpace(name, string.Format(DomainMessages.ArgStringNull, nameof(Name)));
            ArgumentValidator.NullOrWhiteSpace(document, string.Format(DomainMessages.ArgStringNull, nameof(Document)));
            ArgumentValidator.NullOrWhiteSpace(email, string.Format(DomainMessages.ArgStringNull, nameof(Email)));
            ArgumentValidator.EmailFormat(email, string.Format(DomainMessages.ArgInvalidFormat, email));

            Name = name;
            Document = document;
            Email = email;
        }

    }
}
