using EvalTIC.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configuramos la conexi�n a Sql Server
builder.Services.AddDbContext<ApplicationDbContext>(optiones =>
    optiones.UseSqlServer(builder.Configuration.GetConnectionString("SqlConexion"))
    );
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

  pattern: "{controller=Sesion}/{action=Index}/{id?}");

app.Run();
