using WebshopMVC.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebshopDbContext>();
builder.Services.AddSingleton<ICartService, CartService>();

var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
    );


app.Run();
