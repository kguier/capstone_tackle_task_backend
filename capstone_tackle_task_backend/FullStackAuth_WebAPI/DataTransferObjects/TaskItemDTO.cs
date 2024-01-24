namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class TaskItemDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsComplete { get; set; }
    }
}
