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

            builder.Property(dl => dl.LocationId)
                .HasColumnName("location_id");
            
            builder.HasOne(dl => dl.Department)
                .WithMany(d => d.Locations)
                .HasForeignKey("department_id")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}