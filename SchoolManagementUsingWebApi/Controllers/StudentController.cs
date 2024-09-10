using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementUsingWebApi.Models;

namespace SchoolManagementUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext db;
        public StudentController(SchoolDbContext db)
        {
            this.db = db;
        }

        [Route("AddStudent")]
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok("student added sucessfully!!");
        }

        [Route("GetStudent")]
        [HttpGet]
        public IActionResult GetStudent()
        {
            var d = db.Students.ToList();
            return Ok(d);
        }

        [Route("GetTimeTable")]
        [HttpGet]
        public IActionResult GetTimeTable()
        {
            var d = db.Timetables.ToList();
            return Ok(d);
        }

        [Route("GetAssignment")]
        [HttpGet]
        public IActionResult GetAssignment()
        {
            var d = db.Assignments.ToList();
            return Ok(d);
        }

        [Route("GetAttendance")]
        [HttpGet]
        public IActionResult GetAttendance()
        {
            var d = db.Attendances.ToList();
            return Ok(d);
        }
    }
}
