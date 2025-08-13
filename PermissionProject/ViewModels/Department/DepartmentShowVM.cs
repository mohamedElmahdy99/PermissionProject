namespace PermissionProject.ViewModels.Department
{
    public class DepartmentShowVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string ManagerName { get; set; } = string.Empty;


    }
}
