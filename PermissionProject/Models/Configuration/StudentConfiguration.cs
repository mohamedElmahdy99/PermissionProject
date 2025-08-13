using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PermissionProject.Models.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>

    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Intake).IsRequired();
            builder.HasKey(s => s.StudId);



            builder.HasMany(s => s.StudentCourses)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
