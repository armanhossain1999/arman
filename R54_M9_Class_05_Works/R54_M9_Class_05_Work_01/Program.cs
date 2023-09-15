using Microsoft.EntityFrameworkCore;
using R54_M9_Class_05_Work_01.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//    );



app.Run();
