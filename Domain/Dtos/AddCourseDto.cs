using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public record AddCourseDto
    (
        [Required]
        string Name,
        [Required]
        string Code,
        [Required]
        int Credits
    );
}
