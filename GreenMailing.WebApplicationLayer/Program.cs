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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IdentityDbContext<User, Role, int>, GreenMailingDbContext>();

builder.Services.AddScoped<IMessageDal, MessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<GreenMailingDbContext>();
    //.AddErrorDescriber<CustomIdentityValidator>();

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
