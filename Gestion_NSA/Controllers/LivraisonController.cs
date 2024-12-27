using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;


namespace Gestion_NSA.Controllers
{
    public class LivraisonController : Controller
    {
        private readonly ILivraisonService _livraisonService;

        public LivraisonController(ILivraisonService livraisonService)
        {
            _livraisonService = livraisonService;
        }

        public async Task<IActionResult> Index()
        {
            var livraisons = await _livraisonService.GetAllLivraisonsAsync();
            return View(livraisons);
        }

        public async Task<IActionResult> Details(int id)
        {
            var livraison = await _livraisonService.GetLivraisonByIdAsync(id);
            if (livraison == null)
                return NotFound();

            return View(livraison);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livraison livraison)
        {
            if (ModelState.IsValid)
            {
                await _livraisonService.AddLivraisonAsync(livraison);
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livraison = await _livraisonService.GetLivraisonByIdAsync(id);
            if (livraison == null)
                return NotFound();

            return View(livraison);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Livraison livraison)
        {
            if (id != livraison.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _livraisonService.UpdateLivraisonAsync(livraison);
                return RedirectToAction(nameof(Index));
            }
            return View(livraison);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livraison = await _livraisonService.GetLivraisonByIdAsync(id);
            if (livraison == null)
                return NotFound();

            return View(livraison);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _livraisonService.DeleteLivraisonAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
