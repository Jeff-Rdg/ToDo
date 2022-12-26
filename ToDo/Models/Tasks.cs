namespace ToDo.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTask { get; set; }
        public EnumStatusTasks Status { get; set; }
    }
}
