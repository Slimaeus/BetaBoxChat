using BetaBoxChat.Core.Aggregates.Identity;
using BetaBoxChat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BetaBoxChatContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("BetaBoxChat"));
});
builder.Services.AddIdentity<AppUser, AppRole>(s => {
    s.Stores.MaxLengthForKeys = 128;

    s.SignIn.RequireConfirmedPhoneNumber = false;
    s.SignIn.RequireConfirmedEmail = false;
    s.SignIn.RequireConfirmedAccount = false;

    s.Password.RequireNonAlphanumeric = false;
    s.Password.RequireUppercase = false;
    s.Password.RequireDigit = false;
    s.Password.RequiredLength = 0;
    s.Password.RequireLowercase = false;
    s.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<BetaBoxChatContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders(); ;

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
