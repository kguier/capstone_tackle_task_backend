using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class Entry
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string EntryContent { get; set; }

        public DateTime Timestamp { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
