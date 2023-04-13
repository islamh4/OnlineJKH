using Microsoft.EntityFrameworkCore;
using OnlineJKH.BLL;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.BLL.Service;
using OnlineJKH.DAL.EF;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection));
// Add services to the container.
builder.Services.AddTransient<IPersonalAccountService, PersonalAccountService>();
builder.Services.AddTransient<IMeterReadingService, MeterReadingService>();
builder.Services.AddTransient<IReceiptService, ReceiptService>();
builder.Services.AddScoped<DataManager>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
