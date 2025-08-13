

namespace PermissionProject.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public AppBaseUser User { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}
