using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/Entries")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet, Authorize]
        public IActionResult GetAllEntries()
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var entries = _context.Entries.Where(e => e.UserId.Equals(userId));
                return StatusCode(200, entries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<EntriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Entries
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Entry data)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            data.UserId = userId;
            _context.Entries.Add(data);
            _context.SaveChanges();
            return StatusCode(201, data);
        }

        // PUT api/Entries/5
        [HttpPut("{id}"), Authorize]
        public IActionResult PutEntry(int id, [FromBody] Entry updatedEntry)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingEntry = _context.Entries.Find(id);

            if (id != existingEntry.Id)
            {
                return BadRequest("ID Not Found");
            }

            if (existingEntry == null)
            {
                return NotFound("List not found.");
            }

            existingEntry.Title = updatedEntry.Title;
            existingEntry.EntryContent = updatedEntry.EntryContent;
            existingEntry.Timestamp = updatedEntry.Timestamp;
            _context.SaveChanges();

            return StatusCode(201, updatedEntry);
        }

        // DELETE api/<Entries/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteEntry(int id)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingEntry = _context.Entries.Find(id);

            if (existingEntry == null)
            {
                return NotFound("Event not found.");
            }
            _context.Entries.Remove(existingEntry);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
