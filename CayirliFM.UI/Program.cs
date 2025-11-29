using CayirliFM.BusinessLayer.Abstract;
using CayirliFM.BusinessLayer.Concrete;
using CayirliFM.BusinessLayer.External;
using CayirliFM.DataAccessLayer.Abstarct;
using CayirliFM.DataAccessLayer.Concrete;
using CayirliFM.DataAccessLayer.EntityFramework;
using CayirliFM.DataAccessLayer.Repositories;
using CayirliFM.EntityLayer.Contrete;

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

builder.Services.AddHttpClient<IHuggingFaceService, HuggingFaceManager>();

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
