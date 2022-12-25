using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Models;

namespace ToDo.Context.Map
{
    public class TasksMap : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(255)");
            builder.Property(x => x.Description).HasColumnType("varchar(1000)");
            builder.Property(x=>x.DateTask).HasColumnType("date");
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
