using Microsoft.EntityFrameworkCore;
using ScuolaMVC.Data;
using ScuolaMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Configura il DbContext con la connection string da appsettings.json
builder.Services.AddDbContext<ScuolaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34))
    )
);

// Registra la Repository generica nel container DI
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Crea il database se non esiste
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ScuolaContext>();
    context.Database.EnsureCreated();
}

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Route di default - parte da Studente/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Studente}/{action=Index}/{id?}");

app.Run();
