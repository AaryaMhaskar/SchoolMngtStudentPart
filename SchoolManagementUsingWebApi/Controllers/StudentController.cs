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
            student.FeesStatus = "Pending";
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

        [Route("GetFeeStatus")]
        [HttpGet]
        public IActionResult GetFeeStatus()
        {
            var d = db.Students.ToList();
            return Ok(d);
        }

        [Route("GetStudentProfile")]
        [HttpGet]
        public IActionResult GetStudentProfile()
        {
            var d = db.Students.ToList();
            return Ok(d);
        }





        [Route("GetStudentById/{id}")]
        [HttpGet]
        public IActionResult GetStudentById( int id)
        {
            var d = db.Students.Where(x => x.StudentId.Equals(id)).SingleOrDefault();
            return Ok(d);
        }







        [Route("UpdateStudent")]
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student s)
        {
            if (s == null || s.StudentId <= 0)
            {
                return BadRequest("Invalid student data.");
            }

            var student = db.Students.SingleOrDefault(st => st.StudentId == s.StudentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Update student properties
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            student.PhoneNumber = s.PhoneNumber;

            // Update other fields as necessary

            db.SaveChanges();
            return Ok("Student Updated Successfully");
        }

        //ddfjfh
        [Route("UploadFile")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile e)
        {
            var filepath = "Images/" + e.FileName;
            FileStream stream = new FileStream(filepath,FileMode.Create);
            e.CopyTo(stream);
            return Ok(filepath);




        }
    }
}
