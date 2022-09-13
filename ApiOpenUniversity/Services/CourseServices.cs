using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public class CourseServices : ICourseService
    {
        public IEnumerable<Course> GetByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetByStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetWithOutChapters()
        {
            throw new NotImplementedException();
        }
    }
}
