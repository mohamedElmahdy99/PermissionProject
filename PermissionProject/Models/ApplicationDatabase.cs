
namespace PermissionProject.Models
{
    public class ApplicationDatabase :
     IdentityDbContext<AppBaseUser,
     IdentityRole<int>, int, IdentityUserClaim<int>,
    IdentityUserRole<int>, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>

    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;

        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppBaseUser>(entity =>
            {
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.CourseName).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
            modelBuilder.Entity<StudentCourse>()
                .HasKey(StudentCourse => new { StudentCourse.StudentId, StudentCourse.CourseId });
            modelBuilder.Entity<StudentCourse>()
              .Property(s => s.Grade)
              .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
