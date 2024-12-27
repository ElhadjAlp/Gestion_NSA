using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_NSA.Controllers
{
    public class CommandeController : Controller
    {
        private readonly ICommandeService _commandeService;

        public CommandeController(ICommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        public async Task<IActionResult> Index()
        {
            var commandes = await _commandeService.GetAllCommandesAsync();
            return View(commandes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            if (commande == null)
                return NotFound();

            return View(commande);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Commande commande)
        {
            if (ModelState.IsValid)
            {
                await _commandeService.AddCommandeAsync(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            if (commande == null)
                return NotFound();

            return View(commande);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Commande commande)
        {
            if (id != commande.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _commandeService.UpdateCommandeAsync(commande);
                return RedirectToAction(nameof(Index));
            }
            return View(commande);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var commande = await _commandeService.GetCommandeByIdAsync(id);
            if (commande == null)
                return NotFound();

            return View(commande);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _commandeService.DeleteCommandeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
