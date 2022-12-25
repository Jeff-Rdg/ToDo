namespace ToDo.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EnumStatusTasks Status { get; set; }
    }
}
