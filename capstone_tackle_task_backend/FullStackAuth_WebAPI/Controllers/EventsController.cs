using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/Events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet, Authorize]
        public IActionResult GetAllEvents()
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var events = _context.Events.Where(e => e.UserId.Equals(userId));
                return StatusCode(200, events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Events
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Event data)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            data.UserId = userId;
            _context.Events.Add(data);
            _context.SaveChanges();
            return StatusCode(201, data);
        }

        // PUT api/Events/5
        [HttpPut("{id}"), Authorize]
        public IActionResult PutEvent(int id, [FromBody] Event updatedEvent)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingEvent = _context.Events.Find(id);

            if (id != existingEvent.Id)
            {
                return BadRequest("ID Not Found");
            }

            if (existingEvent == null)
            {
                return NotFound("Event not found.");
            }

            existingEvent.Title = updatedEvent.Title;
            existingEvent.DateTime = updatedEvent.DateTime;
            existingEvent.Description = updatedEvent.Description;
            _context.SaveChanges();

            return StatusCode(201, updatedEvent);


    }

        // DELETE api/Events/5
        /*[HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            
        }*/
            

    }
}
