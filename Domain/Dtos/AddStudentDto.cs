using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public record AddStudentDto
    (
        [Required]
        string Name,
        [Required]
        string Document,
        [Required]
        string Email
     );
}
