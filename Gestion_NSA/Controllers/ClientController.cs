using System.Diagnostics;
using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_NSA.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    /* 
        ViewBag => Récupérer le même type
        ViewData => Dictionnaire durant une requête C => V | V => C
        TempData => Dictionnaire durant des requêtes successives
     */

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    // Méthode Index pour afficher tous les clients
    public async Task<IActionResult> Index()
    {
        // Récupère tous les clients via le service
        var clients = await _clientService.GetClientsAsync();
        // Passe les clients à la vue
        return View(clients);
    }

    // Méthode GET pour afficher le formulaire de création
    public IActionResult Create()
    {
        return View();
    }

    // Méthode POST pour créer un nouveau client
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nom,Prenom,Telephone,Adresse,Solde")] Client client)
    {
        if (ModelState.IsValid)
        {
            // Appelle le service pour ajouter un client
            var clientAdded = await _clientService.Create(client);
            TempData["Message"] = "Client créé avec succès!";
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
