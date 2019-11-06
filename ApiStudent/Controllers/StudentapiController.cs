using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudent.Controllers
{
   
    [ApiController]
    public class StudentapiController : ControllerBase
    {
        private static List<StudentDetail> studdet = new List<StudentDetail>();
        private static List<Course> course = new List<Course>();
        [HttpPost("api/studentdetails")]
        public IActionResult Createdetails(StudentDetail student)
        {
            var laststudent = studdet.OrderByDescending(x => x.Id).FirstOrDefault();
            int id = laststudent == null ? 1 : laststudent.Id + 1;
            if (Convert.ToDateTime(student.dateofbirth) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }
            if (Convert.ToDateTime(student.enrollmentdate) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }
            var AddStudent = new StudentDetail
            {
                Id = id,
                Fristname = student.Fristname,
                Lastname = student.Lastname,
                dateofbirth = student.dateofbirth,
                Address = student.Address,
                Phoneno = student.Phoneno,
                courseId = student.courseId,
                enrollmentdate = student.enrollmentdate
            };
            studdet.Add(AddStudent);
            return Ok(AddStudent);
        }
        [HttpGet("api/studentdetails")]
        public IActionResult Getdetails()
        {
            return Ok(studdet);
        }
        [HttpPut("api/studentdetails")]
        public IActionResult viewdetails(StudentDetail student)
        {
            foreach (var entity in studdet)
            {
                if (entity.Id == student.Id)
                {
                    entity.Fristname = student.Fristname;
                    entity.Lastname = student.Lastname;
                    entity.dateofbirth = student.dateofbirth;
                    entity.Address = student.Address;
                    entity.Phoneno = student.Phoneno;
                    entity.courseId = student.courseId;
                    entity.enrollmentdate = student.enrollmentdate;
                    return Ok();
                }
            }

            return NotFound();
        }
        [HttpDelete("api/studentdetails/{id}")]
        public IActionResult delectrecord(int id)
        {
            var selectid = studdet.SingleOrDefault(x => x.Id == id);
            if (selectid == null)
            {
                return NotFound();
            }
            studdet.Remove(selectid);
            return Ok();
        }
        [HttpPost("api/course")]
        public IActionResult Createcourse(Course cour)
        {
            var addcourse = new Course
            {
                courseId=cour.courseId,
                coursename=cour.coursename
            };
            course.Add(addcourse);
            return Ok(addcourse);
        }

        [HttpGet("api/studentdetails2")]
        public IActionResult Getdetailofcourse()
        {
            var viewthecourse = from c in course
                                join s in studdet on c.courseId equals s.courseId into cs
                                //from d in cs.DefaultIfEmpty()
                                group cs by c.coursename into g
                                select new { CourseName = g.Key, Count = g.Count(x => x != null) };
                                
            return Ok(viewthecourse);
        }
    }
}