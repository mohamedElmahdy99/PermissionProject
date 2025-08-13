
namespace PermissionProject.Models
{
    public class StudentCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; } = null!;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public Decimal Grade { get; set; } = 0.0m;
    }
}
