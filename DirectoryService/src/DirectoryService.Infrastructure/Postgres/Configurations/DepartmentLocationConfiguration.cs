using DirectoryService.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    public class DepartmentLocationConfiguration: IEntityTypeConfiguration<DepartmentLocation>
    {
        public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
        {
            builder.ToTable("department_location");
            
            builder.HasKey(dl => dl.Id);
            
            builder.Property(dl => dl.Id)
                .HasColumnName("id");

            builder.Property(dl => dl.DepartmentId)
                .HasColumnName("department_id");
            
            builder.Property(dl => dl.LocationId)
                .HasColumnName("location_id");

            builder.HasOne<Department>()
                .WithMany(d => d.Locations)
                .HasForeignKey(dl => dl.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}