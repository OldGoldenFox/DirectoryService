using DirectoryService.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    public class DepartmentPositionConfiguration: IEntityTypeConfiguration<DepartmentPosition>
    {
        public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
        {
            builder.ToTable("department_position");
            
            builder.HasKey(dp => dp.Id);
            
            builder.Property(dp => dp.Id)
                .HasColumnName("id");
            
            builder.Property(dp => dp.DepartmentId)
                .HasColumnName("department_id");
            
            builder.Property(dp => dp.PositionId)
                .HasColumnName("position_id");
            
            builder.HasOne<Department>()
                .WithMany(d => d.Positions)
                .HasForeignKey(dp => dp.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}