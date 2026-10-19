using Microsoft.EntityFrameworkCore;
using MVCPractice.Middlewares;
using MVCPractice.Models;
using MVCPractice.Repositories;
using MVCPractice.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// تسجيل الـ Service لكي يراها الـ DI Container
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();


builder.Services.AddScoped<IRelativeRepo, RelativeRepo>();
builder.Services.AddScoped<IRelativeService, RelativeService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IProjectService, ProjectService>();



builder.Services.AddTransient<Global_Exception_Handling_Middleware>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// تسجيل AppDbContext داخل الـ Dependency Injection Container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/NotFoundPage");
//app.UseMiddleware<Global_Exception_Handling_Middleware>();
app.UseMiddleware<Global_Exception_Handling_Middleware>();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
