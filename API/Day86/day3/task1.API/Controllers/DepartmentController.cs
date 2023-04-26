using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using task1.API.Data.Context;
using task1.API.Data.Models;

namespace task1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MyContext _context;

        public DepartmentController(UserManager<User> userManager, MyContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            return await _context.Departments.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Dep = await _context.Departments.FindAsync(id);
            if (Dep == null)
            {
                return NotFound();
            }
            return Dep;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Department>> GetByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var Dep = await _context.Departments.FirstOrDefaultAsync(i => i.Name == name);
            if (Dep == null)
            {
                return NotFound();
            }
            return Dep;
        }
        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest();
            }
            department.Id = 0;
            _context.Departments.Add(department);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            var existingdepartment = await _context.Departments.FindAsync(id);
            if (existingdepartment == null)
            {
                return NotFound();
            }

            existingdepartment.Name = department.Name;
            existingdepartment.Id = department.Id;
            existingdepartment.Description = department.Description;
            existingdepartment.Branches = department.Branches;
            existingdepartment.Location = department.Location;
            existingdepartment.Instructors = department.Instructors;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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
        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DelateDepartment(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Dep = await _context.Departments.FindAsync(id);
            if (Dep == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(Dep);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
