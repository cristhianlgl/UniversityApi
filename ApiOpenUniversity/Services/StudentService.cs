﻿using ApiOpenUniversity.Models;

namespace ApiOpenUniversity.Services
{
    public class StudentService : IStudentService
    {
        public IEnumerable<Student> GetByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithCourse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNotCourse()
        {
            throw new NotImplementedException();
        }
    }
}
