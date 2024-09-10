using SchoolManagementUsingWebApi.Models;

namespace SchoolManagementUsingWebApi.REPO
{
    public class StudentService : IStudentRepo
    {
        private readonly SchoolDbContext db;
        public StudentService(SchoolDbContext db)
        {
            this.db = db;
        }
        public void AddStudents(Student student)
        {
           db.Students.Add(student);
           db.SaveChanges();
        }
    }
}
