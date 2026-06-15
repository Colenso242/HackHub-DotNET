using HackHub_DotNET.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackHub_DotNET.Infrastructure.Persistence.Configurations;

public sealed class ContributionConfiguration : IEntityTypeConfiguration<Contribution>
{
    public void Configure(EntityTypeBuilder<Contribution> builder)
    {
        builder.ToTable("Contributions");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(c => c.Type)
               .HasConversion<string>()
               .HasMaxLength(30)
               .IsRequired();
        builder.Property(c => c.Status)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(c => c.SenderId).IsRequired();
        builder.Property(c => c.ReceiverId).IsRequired();
        builder.Property(c => c.HackathonId);
        builder.Property(c => c.TeamId);
        builder.Property(c => c.CreationDate).IsRequired();
        builder.Property(c => c.Message).HasMaxLength(2000);
    }
}
