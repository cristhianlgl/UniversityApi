using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetByCategory(Category category);
        IEnumerable<Course> GetWithOutChapters();
        IEnumerable<Course> GetByStudent(Student student);
    }
}
