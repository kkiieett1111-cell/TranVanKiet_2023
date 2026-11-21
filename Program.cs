using Microsoft.EntityFrameworkCore;
using TranVanKiet_2023.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QLHangHoaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLHangHoaConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HangHoa}/{action=Index}/{id?}");

app.Run();