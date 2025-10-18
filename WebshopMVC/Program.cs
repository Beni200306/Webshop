using WebshopMVC.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebshopDbContext>();
builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<OrderService>();

var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=index}/{id?}"
    );


app.Run();
