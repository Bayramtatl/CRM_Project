using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using CRM_Project.Business.Abstract;
using CRM_Project.Business.Concrete;
using CRM_Project.DataAccess.Abstract;
using CRM_Project.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddSingleton<DbContext, DataContext>();
builder.Services.AddSingleton<ICompanyRepository, CompanyRepository>();
builder.Services.AddSingleton<IServiceRepository, ServiceRepository>();
builder.Services.AddSingleton<IStaffRepository, StaffRepository>();
builder.Services.AddSingleton<IServiceStepRepository, ServiceStepRepository>();
builder.Services.AddSingleton<ICompanyManager, CompanyManager>();
builder.Services.AddSingleton<IServiceManager, ServiceManager>();
builder.Services.AddSingleton<IStaffManager, StaffManager>();
builder.Services.AddSingleton<IServiceStepManager, ServiceStepManager>();
// Oturum açma iþlemleri
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options => {
  options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddNotyf(config =>
{
  config.DurationInSeconds = 5;
  config.IsDismissable = true;
  config.Position = NotyfPosition.BottomCenter;
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
app.UseSession();
app.UseRouting();
app.UseNotyf();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=StaffLogin}/{id?}");

app.Run();
