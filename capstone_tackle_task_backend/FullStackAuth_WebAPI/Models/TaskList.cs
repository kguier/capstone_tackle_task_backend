using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
