using Microsoft.Data.SqlClient;
using NET_CYBER_MOVIE_ASP.DAL.Interfaces;
using NET_CYBER_MOVIE_ASP.DAL.Services;
using NET_CYBER_MOVIE_ASP.Tools;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<SqlConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMoviesService, UserMoviesService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<SessionManager>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
