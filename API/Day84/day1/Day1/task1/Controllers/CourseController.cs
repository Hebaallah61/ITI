using task1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
namespace task1.Controllers
{
    public class CourseController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult get()
        {
            List<Courses> cor = CourseList.Courses.ToList();
            if (cor == null || cor.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(cor);
        }

        [HttpGet("getById/{id}")]
        public IActionResult getById(int id)
        {
            Courses cor = CourseList.Courses.Find(x => x.id == id);
            if (cor == null)
                return NotFound();
            return Ok(cor);
        }
        [HttpGet("couseByName/{name:alpha}")]
        public IActionResult couseByName(string name)
        {
            Courses cor=CourseList.Courses.Find(x=>x.name == name);
            if(cor == null)
                return NotFound();
            return Ok(cor);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult deleteCourse(int id)
        {
            Courses cor = CourseList.Courses.Find(x => x.id == id);
            if (cor == null)
                return NotFound();
            CourseList.Courses.Remove(cor);
            return Ok(cor);
        }
        [HttpPost("postcourses")]
        public IActionResult post(Courses courses)
        {
            if(courses == null) 
                return BadRequest();
            else
            {
            CourseList.Courses.Add(courses);
                return CreatedAtAction(nameof(get), new { id = courses.id }, courses);


            }
           
        }
        [HttpPut("putcourses")]
        public IActionResult put(int id,Courses course)
        {
            if (id != course.id) return BadRequest();
            var exist=CourseList.Courses.Find(x=>x.id== id);
            if(exist==null) return NotFound();
            exist.description = course.description;
            exist.name = course.name;
            exist.duration = course.duration;
            return NoContent();

        }



    }
}
