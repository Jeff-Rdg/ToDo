using System.ComponentModel;

namespace ToDo.Models
{
    public enum EnumStatusTasks
    {
        [Description("Pendente")]
        Pending,
        [Description("Finalizado")]
        Finished
    }
}
