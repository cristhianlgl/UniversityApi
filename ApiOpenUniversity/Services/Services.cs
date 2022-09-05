using ApiOpenUniversity.DataBase;
using ApiOpenUniversity.Enumerations;
using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public class Services
    {
        private readonly AppDbContext _context;
        public Services(AppDbContext context)
        {
            _context = context;
        }

        // search users by email
        public IEnumerable<User> FindUsersByEmail(string email)
        {
            return _context.Users.Where(user => user.Email.Equals(email));
        }

        // Search for older students
        public IEnumerable<Student> FindOlderStudents(int olderAge)
        {
            return _context.Students.Where(student => CalculateAge(student.Dob) >= olderAge);
        }

        public int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now < birthDate.AddYears(age))
                age--;

            return age;
        }

        // Search students who have at least one course
        public IEnumerable<Student> FindStudentsWithCourse()
        {
            return _context.Students.Where(students => students.Courses.Any());
        }

        // Search courses of a given level that have at least one student enrolled
        public IEnumerable<Course> FindCoursesWithStudents(LevelType level)
        {
            return _context.Courses.Where(courses => 
                courses.Level == level && courses.Students.Any());
        }

        // Search courses of a certain level that are of a certain category
        public IEnumerable<Course> FindCoursesByLevelAndCategory(LevelType level, Category searchedCategory)
        {
            return _context.Courses.Where
                    (
                        courses =>
                        courses.Level == level && 
                        courses.Categories
                            .Any(category => category.Id == searchedCategory.Id)
                    );
        }

        // Find courses without students
        public IEnumerable<Course> FindCoursesWithoutStudents()
        {
            return _context.Courses.Where(courses => !courses.Students.Any());
        }

    }
}
