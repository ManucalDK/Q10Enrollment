using Domain.Dtos;
using Domain.Entities;
using Domain.Exceptions.CourseExceptions;
using Domain.Ports.Repository;
using Domain.Ports.Services;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<Course>> GetCourses()
        {
            var courseList = await _courseRepository.GetWithEnrollmentsAsync();

            return courseList.OrderBy(course => course.Name)
                .ThenBy(course => course.Code)
                .ToList();
        }

        public async Task DeleteCourse(Guid id)
        {
            var updateCourse = await _courseRepository.GetByIdAsync(id);
            if (updateCourse is null)
            {
                throw new CourseNotExistException(string.Format(AppMessages.CourseNotexistExceptionMessage, id.ToString()));
            }
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course is null)
            {
                throw new CourseNotExistException(string.Format(AppMessages.StudentNotExistExceptionMessage, id.ToString()));
            }
            return course;
        }

        public async Task AddCourse(AddCourseDto newCourse)
        {
            var courseExist = await _courseRepository.GetcourseByCode(newCourse.Code);

            if (courseExist is not null)
            {
                throw new CourseCodeExistException(string.Format(AppMessages.CourseCodeExistExceptionMessage, newCourse.Code));
            }

            Course course = new(name: newCourse.Name, code: newCourse.Code, credits: newCourse.Credits);
            await _courseRepository.AddAsync(course);
        }

        public async Task UpdateCourse(Guid id, AddCourseDto newCourse)
        {
            var updateCourse = await _courseRepository.GetcourseByCode(newCourse.Code);

            if (updateCourse is not null && !id.Equals(updateCourse.Id))
            {
                throw new CourseCodeExistException(string.Format(AppMessages.CourseCodeExistExceptionMessage, newCourse.Code));
            }

            updateCourse = await _courseRepository.GetByIdAsync(id);
            if (updateCourse is null)
            {
                throw new CourseNotExistException(string.Format(AppMessages.CourseCodeExistExceptionMessage, newCourse.Code));
            }

            updateCourse.UpdateValues(name: newCourse.Name, code: newCourse.Code, credits: newCourse.Credits);

            await _courseRepository.UpdateAsync(updateCourse);
        }


    }
}
