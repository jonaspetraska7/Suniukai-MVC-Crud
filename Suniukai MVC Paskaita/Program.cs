using Microsoft.EntityFrameworkCore;
using Suniukai_MVC_Paskaita.Data;
using Microsoft.AspNetCore.Identity;
using Suniukai_MVC_Paskaita.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SuniukaiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SuniukaiDbContext")));
builder.Services.AddIdentity<Vartotojas, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders().AddDefaultUI();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<Vartotojas>,
    AdditionalUserClaimsPrincipalFactory>();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbContextConnection")));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "admin"));
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope()) { var services = scope.ServiceProvider; var context = services.GetRequiredService<SuniukaiDbContext>(); context.Database.EnsureCreated(); }


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
