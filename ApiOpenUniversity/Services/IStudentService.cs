using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudentsWithCourse();
        IEnumerable<Student> GetStudentsWithNotCourse();
        IEnumerable<Student> GetByCourse(Course course);
    }
}
