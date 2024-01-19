using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Event
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
