using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.BL.Managers.Departments;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentsManager _departmentManager;

        public DepartmentController(IDepartmentsManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_departmentManager.GetAll());
        }
    }
}
