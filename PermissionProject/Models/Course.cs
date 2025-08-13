

namespace PermissionProject.Models
{
    public class Course
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public int InstructorId { get; set; }
        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; } = null!;

    }
}
