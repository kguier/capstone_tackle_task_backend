using FullStackAuth_WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TaskListsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TaskListsController>/5
        [HttpGet("{id}"),]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TaskListsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskListsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/TaskLists/5
        [HttpDelete("{id}"), Authorize]
        public void Delete(int id)
        {
        }
    }
}
