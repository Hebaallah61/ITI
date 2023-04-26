using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task1.API.Data.Context;
using task1.API.Data.Models;
using task1.API.Dto;

namespace task1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;

        public InstructorController(UserManager<User> userManager,MyContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetAll()
        {
            if(_context.Instructors == null)
            {
                return NotFound();
            }
            return await _context.Instructors.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task <ActionResult<Instructor>> GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var ins =await _context.Instructors.FindAsync(id);
            if(ins == null)
            {
                return NotFound();  
            }
            return ins;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Instructor>> GetByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var ins = await _context.Instructors.FirstOrDefaultAsync(i => i.Name == name);
            if (ins == null)
            {
                return NotFound();
            }
            return ins;
        }
        [HttpPost]
        public async Task<ActionResult<Instructor>> AddInstructor(Instructor instructor)
        {
            if( instructor == null)
            {
                return BadRequest();
            }
            _context.Instructors.Add(instructor);   
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = instructor.Id }, instructor);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }

            var existingInstructor = await _context.Instructors.FindAsync(id);
            if (existingInstructor == null)
            {
                return NotFound();
            }

            existingInstructor.Name = instructor.Name;
            existingInstructor.Email = instructor.Email;
            existingInstructor.Phone = instructor.Phone;
            existingInstructor.SSN = instructor.SSN;
            existingInstructor.Age = instructor.Age;
            existingInstructor.Address = instructor.Address;
            existingInstructor.Salary = instructor.Salary;
            existingInstructor.DOB = instructor.DOB;
            existingInstructor.Password = instructor.Password;
            existingInstructor.DepartmentId = instructor.DepartmentId;
            existingInstructor.Department = instructor.Department;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Instructor>> DelateInstructor(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var ins =await _context.Instructors.FindAsync(id);
            if(ins == null)
            {
                return NotFound();
            }
            _context.Instructors.Remove(ins);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

   

}
