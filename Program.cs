using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CrudEstudiantes.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
// Configurar DbContext antes de construir la aplicación.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Configuración de CORS
// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173") // Incluye ambas URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "API para CRUD básico en .NET 8 MVC",
        Contact = new OpenApiContact
        {
            Name = "David",
            Email = "gabo3000lizama@gmail.com"
        }
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = ""; // Configura Swagger en la raíz (localhost:5000)
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

