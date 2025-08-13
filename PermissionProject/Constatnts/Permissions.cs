namespace PermissionProject.Constatnts
{
    public class Permissions
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Manager = "Manager";
        public const string Instructor = "Instructor";
        public const string Student = "Student";
        public const string Permission = "Permission";

        public static List<string> GeneratePermissions(string model)
        {
            return new List<string>
            {
                $"Permission.{model}.Create",
                $"Permission.{model}.Update",
                $"Permission.{model}.Delete",
                $"Permission.{model}.View",
            };
        }
    }
}
