using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaktolusApp.Interfaces;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Models;
using PaktolusApp.Repositories;
using PaktolusApp.Services; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbTestContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

//Repositories
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IHobbyRepository, HobbyRepository>();

//Services
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IHobbyService, HobbyService>(); 


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();

