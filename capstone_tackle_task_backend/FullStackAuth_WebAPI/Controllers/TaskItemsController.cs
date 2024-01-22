using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/TaskItems")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/TaskItems
        [HttpGet, Authorize]
        public IActionResult GetAllTaskItemsInAList()
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var taskItems = _context.TaskItems.Where(e => e.TaskListId.Equals(userId));
                return StatusCode(200, taskItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TaskItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
