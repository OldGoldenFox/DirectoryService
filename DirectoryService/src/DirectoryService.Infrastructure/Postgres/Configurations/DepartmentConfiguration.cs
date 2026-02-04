using DirectoryService.Domain;
using DirectoryService.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments");
            
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("id");
            
            builder.OwnsOne(
                d => d.Name, name =>
            {
                name.Property(d => d.Value )
                    .IsRequired()
                    .HasMaxLength(LengthConstants.LENGTH150)
                    .HasColumnName("name");
            });
            
            builder.OwnsOne(
                d => d.Identifier, identifier =>
                {
                    identifier.Property(d => d.Value )
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH150)
                        .HasColumnName("identifier");
                });
            
            builder.Property(d => d.ParentId)
                .IsRequired(false)
                .HasColumnName("parent_id");
            
            builder.OwnsOne(
                d => d.Path, path =>
                {
                    path.Property(d => d.Value )
                        .IsRequired()
                        .HasColumnName("path");
                });
            
            builder.Property(d => d.Depth)
                .IsRequired()
                .HasColumnName("depth");
            
            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasColumnName("is_active");
            
            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            
            builder.Property(d => d.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}