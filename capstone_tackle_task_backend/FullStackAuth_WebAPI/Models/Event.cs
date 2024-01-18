using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.Models
{
    public class Event
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }
    }
}
