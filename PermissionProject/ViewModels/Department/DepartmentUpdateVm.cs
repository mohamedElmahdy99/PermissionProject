using Microsoft.AspNetCore.Mvc.Rendering;

namespace PermissionProject.ViewModels.Department
{
    public class DepartmentUpdateVm
    {
        public int DeptId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string DepartmentName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Manager is required.")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }
        public List<SelectListItem> Managers { get; set; } = new List<SelectListItem>();

    }
}
