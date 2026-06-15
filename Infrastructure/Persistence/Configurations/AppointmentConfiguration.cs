using HackHub_DotNET.Domain;
using HackHub_DotNET.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackHub_DotNET.Infrastructure.Persistence.Configurations;

public sealed class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedNever();

        builder.Property(a => a.MentorId).IsRequired();
        builder.Property(a => a.TeamId).IsRequired();
        builder.Property(a => a.HackathonId).IsRequired();

        // DateRange value object -> two columns in the Appointments table.
        builder.OwnsOne(a => a.Slot, slot =>
        {
            slot.Property(s => s.Start).HasColumnName("StartTime").IsRequired();
            slot.Property(s => s.End).HasColumnName("EndTime").IsRequired();
        });
        builder.Navigation(a => a.Slot).IsRequired();

        builder.Property(a => a.MeetingUrl)
               .HasConversion(new UrlConverter())
               .HasMaxLength(2048);
    }
}
