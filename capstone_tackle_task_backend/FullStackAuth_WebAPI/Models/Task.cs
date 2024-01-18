using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsComplete { get; set; }
    }
}
