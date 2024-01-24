using FullStackAuth_WebAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class TaskListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }

    }
}
