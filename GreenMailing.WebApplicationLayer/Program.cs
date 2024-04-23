using GreenMailing.BusinessLayer.Abstract.IAbstractService;
using GreenMailing.BusinessLayer.Concrete.ConcreteManager;
using GreenMailing.DataAccessLayer.Abstract.IAbstractDal;
using GreenMailing.DataAccessLayer.Abstract.IGenericRepository;
using GreenMailing.DataAccessLayer.Concrete.ConcreteDal.EntityFramework;
using GreenMailing.DataAccessLayer.Concrete.Context;
using GreenMailing.DataAccessLayer.Concrete.GenericRepository;
using GreenMailing.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using GreenMailing.BusinessLayer.Concrete.ValidationRules.UserValidationRules;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IdentityDbContext<User, Role, int>, GreenMailingDbContext>();

builder.Services.AddScoped<IMessageDal, MessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<GreenMailingDbContext>();

builder.Services.AddFluentValidationAutoValidation(config =>
{
	config.DisableDataAnnotationsValidation = true;
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
