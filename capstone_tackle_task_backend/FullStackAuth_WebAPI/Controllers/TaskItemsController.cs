using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
       /* public IActionResult GetAllTaskItemsInAList()
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            
            return StatusCode(200, taskItems);
        }*/

        // GET api/<TaskItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/TaskItems
        [HttpPost, Authorize]
        public IActionResult PostTaskItem([FromBody] TaskItem data)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            _context.TaskItems.Add(data);
            _context.SaveChanges();
            return StatusCode(201, data);
        }

        // PUT api/TaskItems/5
        [HttpPut("{id}"), Authorize]
        public IActionResult PutTaskItem(int id, [FromBody] TaskItem updatedTaskItem)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingTaskItem = _context.TaskItems.Find(id);

            if (id != existingTaskItem.Id)
            {
                return BadRequest("ID Not Found");
            }

            if (existingTaskItem == null)
            {
                return NotFound("Task not found.");
            }

            existingTaskItem.Content = updatedTaskItem.Content;
            existingTaskItem.IsComplete = updatedTaskItem.IsComplete;
            existingTaskItem.TaskListId = updatedTaskItem.TaskListId;
            _context.SaveChanges();

            return StatusCode(201, updatedTaskItem);
        }

        // DELETE api/<TaskItemsController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteTaskItem(int id)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingTaskItem = _context.TaskItems.Find(id);

            if (existingTaskItem == null)
            {
                return NotFound("Task not found.");
            }
            _context.TaskItems.Remove(existingTaskItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
