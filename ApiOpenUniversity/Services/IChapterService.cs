using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public interface IChapterService
    {
        IEnumerable<Chapter> GetByCourse(Course course);
    }
}
