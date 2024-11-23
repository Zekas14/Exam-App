using ExaminationSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminationSystem.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(25);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
            builder.ToTable("Courses");
        }
    }
}
