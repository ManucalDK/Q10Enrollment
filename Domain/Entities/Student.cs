using Domain.Helpers;

namespace Domain.Entities
{
    public class Student : DefaultEntity
    {
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


        public Student(string name, string document, string email)
        {
            Validate(name, document, email);
            Name = name;
            Document = document;
            Email = email;
        }
        private static void Validate(string name, string document, string email)
        {
            ArgumentValidator.NullOrWhiteSpace(name, string.Format(DomainMessages.ArgStringNull, nameof(Name)));
            ArgumentValidator.NullOrWhiteSpace(document, string.Format(DomainMessages.ArgStringNull, nameof(Document)));
            ArgumentValidator.NullOrWhiteSpace(email, string.Format(DomainMessages.ArgStringNull, nameof(Email)));
            ArgumentValidator.EmailFormat(email, string.Format(DomainMessages.ArgInvalidFormat, email));
        }

        public void UpdateValues(string name, string document, string email)
        {
            Validate(name, document, email);
            Name = name;
            Document = document;
            Email = email;
        }

    }
}
