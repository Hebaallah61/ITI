using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.BL.Dtos.Developers;
using Tickets.BL.Dtos.Tickets;
using Tickets.BL.Managers.Tickets;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketsManager _ticketManager;

        public TicketController(ITicketsManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_ticketManager.GetAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Details(int Id)
        {
            var ticket = _ticketManager.GetById(Id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var deleted = _ticketManager.Delete(Id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Id = _ticketManager.Create(ticket);
            return CreatedAtAction(actionName: nameof(Details), routeValues: new { Id }, new { Message = "Created Successfully" });
        }

        [HttpPost("{Id}")]
        public IActionResult EditDevelopers(int Id, InsertdevelopersDto developers)
        {
            return Ok(_ticketManager.EditDevelopers(Id, developers));
        }
    }
}
