using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/taskLists")]
    [ApiController]
    public class TaskListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskLists
        [HttpGet, Authorize]
        public IActionResult GetAllTaskLists()
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var taskLists = _context.TaskLists.Select(l => new TaskListDTO
            {
                Id = l.Id,
                Name = l.Name,
                TaskItems = _context.TaskItems.Where(t => t.TaskListId == l.Id).ToList()
            }) ;
            
            return StatusCode(200, taskLists);
        }


        // POST api/TaskLists
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] TaskList data)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            data.UserId = userId;
            _context.TaskLists.Add(data);
            _context.SaveChanges();
            return StatusCode(201, data);
        }

        // PUT api/TaskLists/5
        [HttpPut("{id}"), Authorize]
        public IActionResult PutTaskList(int id, [FromBody] TaskList updatedTaskList)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingTaskList = _context.TaskLists.Find(id);

            if (id != existingTaskList.Id)
            {
                return BadRequest("ID Not Found");
            }

            if (existingTaskList == null)
            {
                return NotFound("List not found.");
            }

            existingTaskList.Name = updatedTaskList.Name;
            _context.SaveChanges();

            return StatusCode(201, updatedTaskList);

        }

        // DELETE api/TaskLists/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult DeleteTaskList(int id)
        {
            string userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var existingTaskList = _context.TaskLists.Find(id);

            if (existingTaskList == null)
            {
                return NotFound("Event not found.");
            }
            _context.TaskLists.Remove(existingTaskList);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
