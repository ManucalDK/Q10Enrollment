namespace Domain.Entities
{
    public class Enrollment : DefaultEntity
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
