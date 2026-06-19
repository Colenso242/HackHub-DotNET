using HackHub_DotNET.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackHub_DotNET.Infrastructure.Persistence.Configurations;

public sealed class HackathonConfiguration : IEntityTypeConfiguration<Hackathon>
{
    public void Configure(EntityTypeBuilder<Hackathon> builder)
    {
        builder.ToTable("Hackathons");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id).ValueGeneratedNever();

        builder.Property(h => h.Name).IsRequired().HasMaxLength(200);
        builder.Property(h => h.Rules).IsRequired().HasMaxLength(2000);
        builder.Property(h => h.Location).IsRequired().HasMaxLength(200);
        builder.Property(h => h.Prize);
        builder.Property(h => h.EnrollmentDeadline).IsRequired();
        builder.Property(h => h.State)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();
        builder.Property(h => h.MaxTeamSize);
        builder.Property(h => h.OrganizerId).IsRequired();
        builder.Property(h => h.JudgeId).IsRequired();
        builder.Property(h => h.WinnerId);

        // DateRange value object -> two columns in the Hackathons table.
        builder.OwnsOne(h => h.Period, period =>
        {
            period.Property(p => p.Start).HasColumnName("StartDate").IsRequired();
            period.Property(p => p.End).HasColumnName("EndDate").IsRequired();
        });
        builder.Navigation(h => h.Period).IsRequired();

        builder.PrimitiveCollection(h => h.MentorIds)
               .HasField("_mentorIds")
               .UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.PrimitiveCollection(h => h.TeamIds)
               .HasField("_teamIds")
               .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
