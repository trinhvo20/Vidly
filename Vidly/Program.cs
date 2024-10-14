using Microsoft.EntityFrameworkCore;
using Vidly.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VidlyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

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

/*
// Custom Routes
app.MapControllerRoute(
    name: "MoviesByReleaseDate",
    pattern: "movies/released/{year}/{month}",
    defaults: new {controller="Movies", action="ByReleaseDate"},
    new { year = @"\d{4}", month = @"\d{2}"} // constraint: year 4 digits, month 2 digits
);
*/

// Default Route to Home
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();








/*
Model - Controller - View

Model - object for holding data from database.
Controller - actions between the model and the view, receiving user input and deciding what to do with it.
View - the frontend.

Each View will have its own Controller.

Link for MVC Movie/Ramdon page:
https://localhost:7126/Movie/Random

Bootstrap: 
https://bootswatch.com/

Course Link:
https://www.youtube.com/watch?v=j-JpI4QcQh4&list=PLOghUv2IDLKEVhfuIJQnl3HxeXwtRvmsr&index=20

How to setup DB in Core:
https://www.youtube.com/watch?v=RWXKysImabs

Database: Vidly
Tables:
    Customers
    Movies
 

Models:
    Movie
    Customer
        MembershipType
 */