using DirectoryService.Domain;
using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations
{
    public class LocationConfiguration: IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");
            
            builder.HasKey(l => l.Id);
            
            builder.Property(l => l.Id)
                .HasColumnName("id");

            builder.OwnsOne(
                l => l.Name, name =>
                {
                    name.Property(l => l.Value)
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH120)
                        .HasColumnName("name");
                });

            builder.OwnsOne(
                l => l.Address, address =>
                {
                    address.Property(l => l.Country)
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH100)
                        .HasColumnName("country");
                    
                    address.Property(l => l.City)
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH100)
                        .HasColumnName("city");
                    
                    address.Property(l => l.Street)
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH100)
                        .HasColumnName("street");
                    
                    address.Property(l => l.HouseNumber)
                        .IsRequired()
                        .HasMaxLength(LengthConstants.LENGTH10)
                        .HasColumnName("house_number");
                });
            
            builder.OwnsOne(
                l => l.Timezone, timezone =>
                {
                    timezone.Property(l => l.Value)
                        .IsRequired()
                        .HasColumnName("timezone");
                });

            builder.Property(l => l.IsActive)
                .IsRequired()
                .HasColumnName("is_active");

            builder.Property(l => l.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            
            builder.Property(l => l.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
        }
    }
}