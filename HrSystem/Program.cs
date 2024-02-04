using HrSystem.Data;
using HrSystem.Server;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//dependence inject container
builder.Services.AddScoped<ICountryInterface, CountryServer>();
builder.Services.AddScoped<ICityInterface, CityServe>();
builder.Services.AddScoped<IDeptInterface, DepatServe>();
builder.Services.AddScoped<IEmpInterface, EmploServes>();
builder.Services.AddScoped<IAccountInterface, AccountServes>();
builder.Services.AddDbContext<HrContext>();
//add auto mapper to IOC
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//add identityFramework
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HrContext>();

builder.Services.ConfigureApplicationCookie(c =>
{
    c.LoginPath = "/Account/Sigin";
    c.ExpireTimeSpan = TimeSpan.FromDays(2);
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Sigin}/{id?}");

app.Run();
