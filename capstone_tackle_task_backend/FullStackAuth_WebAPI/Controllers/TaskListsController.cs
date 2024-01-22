using FullStackAuth_WebAPI.Data;
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
            try
            {
                string userId = User.FindFirstValue("id");
                var taskLists = _context.TaskLists.Where(e => e.UserId.Equals(userId));
                return StatusCode(200, taskLists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TaskListsController>/5
        [HttpGet("{id}"),]
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}
