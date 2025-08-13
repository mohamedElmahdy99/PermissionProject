namespace PermissionProject.Constatnts
{
    public class Account
    {
        //SuperAdmin Data
        public const string SuperAdminEmail = "SuperAdmin@gamil.com";
        public const string SuperAdminFirstName = "SuperAdmin@12345";
        public const string SuperAdminLastName = "SuperAdmin@12345";
        public const string SuperAdminPassword = "SuperAdmin@12345";

        //Instructor Data
        public const string InstructorEmail = "Instructor@gamil.com";
        public const string InstructorFirstName = "Instructor@12345";
        public const string InstructorLastName = "Instructor@12345";
        public const string InstructorPassword = "Instructor@12345";

        //Student Data
        public const string StudentEmail = "Student@gamil.com";
        public const string StudentFirstName = "Student@12345";
        public const string StudentLastName = "Student@12345";
        public const string StudentPassword = "Student@12345";

        //Manager Data
        public const string ManagerEmail = "Manager@gamil.com";
        public const string ManagerFirstName = "Manager@12345";
        public const string ManagerLastName = "Manager@12345";
        public const string ManagerPassword = "Manager@12345";

        public enum Roles
        {
            SuperAdmin,
            Manager,
            Student,
            Instructor,
        }
        public enum PermissionModels
        {
            Department,
            Course,
            Student,
            Manager,
            Instructor,
        }
    }
}
