using WebshopMVC.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebshopDbContext>();

var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
    );


app.Run();
