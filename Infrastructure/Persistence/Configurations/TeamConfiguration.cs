using HackHub_DotNET.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackHub_DotNET.Infrastructure.Persistence.Configurations;

public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedNever();

        builder.Property(t => t.Name).IsRequired().HasMaxLength(25);
        builder.Property(t => t.LeaderId).IsRequired();
        builder.Property(t => t.Deleted).IsRequired();

        // Member ids travel with the Team aggregate (no navigation to the User root).
        builder.PrimitiveCollection(t => t.MemberIds)
               .HasField("_memberIds")
               .UsePropertyAccessMode(PropertyAccessMode.Field);

        // Soft delete: hide flagged rows (mirrors the reference @SQLDelete behaviour).
        builder.HasQueryFilter(t => !t.Deleted);
    }
}
