
namespace PermissionProject.Models
{
    public class ApplicationDatabase : IdentityDbContext<AppBaseUser, IdentityRole<int>, int>
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
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AppBaseUser>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<AppBaseUser>().Property(u => u.LastName).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Department>().Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<Course>().Property(c => c.CourseName).IsRequired().HasMaxLength(100);
            //modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.StudentId).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.StudentId);
            //modelBuilder.Entity<StudentCourse>().HasOne(sc => sc.CourseId).WithMany(c => c.StudentCourses).HasForeignKey(sc => sc.CourseId);
        }
    }
}
