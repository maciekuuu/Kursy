using Kursy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
var builder = WebApplication.CreateBuilder(args);

const string connectionSting = "data source=LAPTOP-S66849AA\\SQLEXPRESS;initial catalog=Test;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;Trust Server Certificate=true";
//const string connectionSting = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Test;Data\r\n";
//const string connectionSting = "Server=LAPTOP-S66849AA\\SQLEXPRESS;Catalog=Test;Integrated Security=True;";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(connectionSting));

//builder.Services.AddSession();


builder.Services.AddSession(options =>
{
    options.Cookie.Name = "My.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
