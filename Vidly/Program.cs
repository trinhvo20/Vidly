var builder = WebApplication.CreateBuilder(args);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

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
*/