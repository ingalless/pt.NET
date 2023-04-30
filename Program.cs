using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PT.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PTContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PTContext") ?? throw new InvalidOperationException("Connection string 'PTContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
