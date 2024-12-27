using Gestion_NSA.Data;
using Gestion_NSA.Fixtures;
using Gestion_NSA.Services;
using Gestion_NSA.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Enregistrer ApplicationDbContext pour l'accès à la base de données
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// L'injection des services : enregistrement des interfaces et de leurs implémentations
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<ILivraisonService, LivraisonService>();
builder.Services.AddScoped<ILivreurService, LivreurService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IProduitCommandeService, ProduitCommandeService>();
builder.Services.AddScoped<ClientFixtures>();

// Ajouter les services nécessaires au conteneur.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// Configurer les routes pour les contrôleurs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}");


    // Load Fixtures
using (var scope = app.Services.CreateScope())

{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    seeder.Load();
}

app.Run();
