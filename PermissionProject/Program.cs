using PermissionProject.Models;
using PermissionProject.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDatabase>(opt =>
{
    opt.UseSqlServer(connectionString).UseLazyLoadingProxies();
});

builder.Services.AddIdentity<AppBaseUser, IdentityRole<int>>(opt =>
{
    opt.Password.RequiredLength = 6;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
})
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDatabase>();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var UerManager = services.GetRequiredService<UserManager<AppBaseUser>>();
    var RoleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await Seed.SeedRoles(RoleManager);
    await Seed.SeedSuperAdmin(UerManager, RoleManager);
    await Seed.SeedStudent(UerManager, RoleManager);
    await Seed.SeedManager(UerManager, RoleManager);
    await Seed.SeedInstructor(UerManager, RoleManager);
    await RoleManager.SeepSuperAdminPermissions();

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
