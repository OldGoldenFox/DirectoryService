using DirectoryService.Domain;
using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    public class PositionConfiguration: IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions");
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.OwnsOne(
                p => p.Name, name =>
            {
               name.Property(p => p.Value)
                   .IsRequired()
                   .HasMaxLength(LengthConstants.LENGTH100)
                   .HasColumnName("name");
            });
            
            builder.OwnsOne(
                p => p.Description, description =>
            {
                description.Property(p => p.Value)
                    .HasMaxLength(LengthConstants.LENGTH1000)
                    .HasColumnName("description");
            });

            builder.Navigation(p => p.Description)
                .IsRequired(false);

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasColumnName("is_active");
            
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            
            builder.Property(p => p.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}