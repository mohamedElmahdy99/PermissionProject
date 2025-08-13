

namespace PermissionProject.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudId { get; set; }

        public int Intake { get; set; }

        [ForeignKey("StudId")]
        public AppBaseUser User { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; } = null!;

    }
}
