using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Repository;
using TrafficFineSystemWeb.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.Configure<IdentityOptions>(op =>
{
    op.Password.RequireNonAlphanumeric = false;
    op.Password.RequiredLength = 3;
    op.Password.RequireDigit = false;
    op.Password.RequireUppercase = false;
    op.Password.RequireLowercase = false;
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


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

app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
