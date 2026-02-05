using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.BusinessLayer.Concrete;
using CayirliFM.BusinessLayer.External;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.EntityFramework;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;
using CayirliFM.UI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<ICategoryDal, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IAboutDal, EfAboutRepository>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<INewsDal, EfNewsRepository>();
builder.Services.AddScoped<INewsService, NewsManager>();

builder.Services.AddScoped<IContactDal, EfContactRepository>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IReplyToContactDal, EfReplyToContactRepository>();
builder.Services.AddScoped<IReplyToContactService, ReplyToContactManager>();

builder.Services.AddScoped<IStartegyDal, EfStrategyRepository>();
builder.Services.AddScoped<IStrategyService, StrategyManager>();

builder.Services.AddScoped<IAddressDal, EfAddressRepository>();
builder.Services.AddScoped<IAddressService, AddressManager>();

builder.Services.AddScoped<ISocialMediaAccountsDal, EfSocialMediaAccountsRepository>();
builder.Services.AddScoped<ISocialMediaAccountsService, SocialMediaAccountsManager>();

builder.Services.AddScoped<IWelcomeToOurSiteDal, EfWelcomeToOurSiteRepository>();
builder.Services.AddScoped<IWelcomeToOurSiteService, WelcomeToOurSiteManager>();

builder.Services.AddScoped<IEventDal, EfEventRepository>();
builder.Services.AddScoped<IEventService, EventManager>();

builder.Services.AddScoped<ICategoryEventDal, EfCategoryEventRepository>();
builder.Services.AddScoped<ICategoryEventService, CategoryEventManager>();

builder.Services.AddScoped<ICommentDal, EfCommentRepository>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IEmployeeDal, EfEmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();

builder.Services.AddScoped<IPlaylistDal, EfPlaylistRepository>();
builder.Services.AddScoped<IPlaylistService, PlaylistManager>();

builder.Services.AddScoped<IMusicDal, EfMusicRepository>();
builder.Services.AddScoped<IMusicService, MusicManager>();

builder.Services.AddHttpClient<IHuggingFaceService, HuggingFaceManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<Context>();

// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/LoginUser/";
    options.AccessDeniedPath = "/Login/AccessDenied/";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
});

builder.Services.AddSignalR();

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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.MapHub<MusicHub>("/musichub");

app.Run();
