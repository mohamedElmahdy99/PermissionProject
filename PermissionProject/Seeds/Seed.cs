using PermissionProject.Constatnts;
using PermissionProject.Models;
using System.Security.Claims;
using static PermissionProject.Constatnts.Account;

namespace PermissionProject.Seeds
{
    public static class Seed
    {
        //Seeding Roles
        public static async Task SeedRoles(RoleManager<IdentityRole<int>> _roleManager)
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(Constatnts.Account.Roles.Manager.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(Constatnts.Account.Roles.Manager.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(Constatnts.Account.Roles.Student.ToString()));
                await _roleManager.CreateAsync(new IdentityRole<int>(Constatnts.Account.Roles.Instructor.ToString()));
            }
        }

        public static async Task SeedManager(UserManager<AppBaseUser> _userManager, RoleManager<IdentityRole<int>> _roleManager)
        {
            var Manager = new AppBaseUser()
            {
                UserName = Account.ManagerEmail,
                Email = Account.ManagerEmail,
                FirstName = Account.ManagerFirstName,
                LastName = Account.ManagerLastName,
                IsActive = true,
                EmailConfirmed = true,

            };
            var ManagerResult = await _userManager.FindByEmailAsync(Account.ManagerEmail);
            if (ManagerResult == null)
            {
                var result = await _userManager.CreateAsync(Manager, Account.ManagerPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(Manager, Constatnts.Account.Roles.Manager.ToString());
                }
            }
            //SeedPermissions(_roleManager, Manager);

        }
        public static async Task SeedInstructor(UserManager<AppBaseUser> _userManager, RoleManager<IdentityRole<int>> _roleManager)
        {
            var Manager = new AppBaseUser()
            {
                UserName = Account.ManagerEmail,
                Email = Account.ManagerEmail,
                FirstName = Account.ManagerFirstName,
                LastName = Account.ManagerLastName,
                IsActive = true,
                EmailConfirmed = true,

            };
            var ManagerResult = await _userManager.FindByEmailAsync(Account.ManagerEmail);
            if (ManagerResult == null)
            {
                var result = await _userManager.CreateAsync(Manager, Account.ManagerPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(Manager, Constatnts.Account.Roles.Manager.ToString());
                }
            }
            //SeedPermissions(_roleManager, Manager);

        }
        public static async Task SeedStudent(UserManager<AppBaseUser> _userStudent, RoleManager<IdentityRole<int>> _roleStudent)
        {
            var Student = new AppBaseUser()
            {
                UserName = Account.StudentEmail,
                Email = Account.StudentEmail,
                FirstName = Account.StudentFirstName,
                LastName = Account.StudentLastName,
                IsActive = true,
                EmailConfirmed = true,

            };
            var StudentResult = await _userStudent.FindByEmailAsync(Account.StudentEmail);
            if (StudentResult == null)
            {
                var result = await _userStudent.CreateAsync(Student, Account.StudentPassword);
                if (result.Succeeded)
                {
                    await _userStudent.AddToRoleAsync(Student, Constatnts.Account.Roles.Student.ToString());
                }
            }
            //SeedPermissions(_roleStudent, Student);

        }
        public static async Task SeedSuperAdmin(UserManager<AppBaseUser> _userSuperAdmin, RoleManager<IdentityRole<int>> _roleSuperAdmin)
        {
            var SuperAdmin = new AppBaseUser()
            {
                UserName = Account.SuperAdminEmail,
                Email = Account.SuperAdminEmail,
                FirstName = Account.SuperAdminFirstName,
                LastName = Account.SuperAdminLastName,
                IsActive = true,
                EmailConfirmed = true,

            };
            var SuperAdminResult = await _userSuperAdmin.FindByEmailAsync(Account.SuperAdminEmail);
            if (SuperAdminResult == null)
            {
                var result = await _userSuperAdmin.CreateAsync(SuperAdmin, Account.SuperAdminPassword);
                if (result.Succeeded)
                {
                    await _userSuperAdmin.AddToRoleAsync(SuperAdmin, Constatnts.Account.Roles.SuperAdmin.ToString());
                }
            }
            //SeedPermissions(_roleSuperAdmin, SuperAdmin);

        }

        public static async Task SeepSuperAdminPermissions(this RoleManager<IdentityRole<int>> _rolemanager)
        {
            var superAdminRole = await _rolemanager.FindByNameAsync(Constatnts.Account.Roles.SuperAdmin.ToString());
            if (superAdminRole == null)
                return;
            var models = Enum.GetValues(typeof(PermissionModels));
            foreach (var model in models)
                await _rolemanager.SeedPermissions(superAdminRole, model.ToString());

        }

        public static async Task SeedPermissions(this RoleManager<IdentityRole<int>> _roleManager, IdentityRole<int> Role, string Model)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(s => s.Name == Account.Roles.SuperAdmin.ToString());

            var allSuperAdminClaims = await _roleManager.GetClaimsAsync(role);

            var allPErmissions = Permissions.GeneratePermissions(Model);
            foreach (var permission in allPErmissions)
                if (!allSuperAdminClaims.Any(s => s.Type == Permissions.Permission && s.Value == permission))
                    await _roleManager.AddClaimAsync(role, new Claim(Permissions.Permission, permission));
        }

    }
}
