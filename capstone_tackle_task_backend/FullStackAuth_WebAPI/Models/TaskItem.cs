using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsComplete { get; set; }

        [ForeignKey("TaskList")]
        public int TaskListId { get; set; }
    }
}
