using HackHub_DotNET.Domain;
using HackHub_DotNET.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackHub_DotNET.Infrastructure.Persistence.Configurations;

public sealed class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.ToTable("Submissions");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever();

        builder.Property(s => s.RepositoryUrl)
               .HasConversion(new UrlConverter())
               .HasMaxLength(2048)
               .IsRequired();

        builder.Property(s => s.HackathonId).IsRequired();
        builder.Property(s => s.TeamId).IsRequired();
        builder.Property(s => s.LastEditedById).IsRequired();
        builder.Property(s => s.UpdatedAt).IsRequired();

        // Grade value object is optional (null until a judge scores the submission).
        builder.OwnsOne(s => s.Grade, grade =>
        {
            grade.Property(g => g.Score).HasColumnName("Score");
            grade.Property(g => g.Comment).HasColumnName("GradeComment").HasMaxLength(1000);
        });
    }
}
