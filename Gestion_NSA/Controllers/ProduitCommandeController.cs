using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_NSA.Controllers
{
    public class ProduitCommandeController : Controller
    {
        private readonly IProduitCommandeService _produitCommandeService;

        public ProduitCommandeController(IProduitCommandeService produitCommandeService)
        {
            _produitCommandeService = produitCommandeService;
        }

        public async Task<IActionResult> Index()
        {
            var produitCommandes = await _produitCommandeService.GetAllProduitCommandesAsync();
            return View(produitCommandes);
        }

        public IActionResult Create()
        {
            return View(new ProduitCommande());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProduitCommande produitCommande)
        {
            if (ModelState.IsValid)
            {
                await _produitCommandeService.AddProduitCommandeAsync(produitCommande);
                return RedirectToAction(nameof(Index));
            }
            return View(produitCommande);
        }

        public async Task<IActionResult> Edit(int commandeId, int produitId)
        {
            var produitCommande = await _produitCommandeService.GetProduitCommandeByIdAsync(commandeId, produitId);
            if (produitCommande == null)
            {
                return NotFound();
            }
            return View(produitCommande);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProduitCommande produitCommande)
        {
            if (ModelState.IsValid)
            {
                await _produitCommandeService.UpdateProduitCommandeAsync(produitCommande);
                return RedirectToAction(nameof(Index));
            }
            return View(produitCommande);
        }

        public async Task<IActionResult> Delete(int commandeId, int produitId)
        {
            var produitCommande = await _produitCommandeService.GetProduitCommandeByIdAsync(commandeId, produitId);
            if (produitCommande == null)
            {
                return NotFound();
            }
            return View(produitCommande);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int commandeId, int produitId)
        {
            await _produitCommandeService.DeleteProduitCommandeAsync(commandeId, produitId);
            return RedirectToAction(nameof(Index));
        }
    }
}
