using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;


namespace Gestion_NSA.Controllers
{
    public class LivreurController : Controller
    {
        private readonly ILivreurService _livreurService;

        public LivreurController(ILivreurService livreurService)
        {
            _livreurService = livreurService;
        }

        public async Task<IActionResult> Index()
        {
            var livreurs = await _livreurService.GetAllLivreursAsync();
            return View(livreurs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var livreur = await _livreurService.GetLivreurByIdAsync(id);
            if (livreur == null)
                return NotFound();

            return View(livreur);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                await _livreurService.AddLivreurAsync(livreur);
                return RedirectToAction(nameof(Index));
            }
            return View(livreur);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livreur = await _livreurService.GetLivreurByIdAsync(id);
            if (livreur == null)
                return NotFound();

            return View(livreur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Livreur livreur)
        {
            if (id != livreur.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _livreurService.UpdateLivreurAsync(livreur);
                return RedirectToAction(nameof(Index));
            }
            return View(livreur);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livreur = await _livreurService.GetLivreurByIdAsync(id);
            if (livreur == null)
                return NotFound();

            return View(livreur);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _livreurService.DeleteLivreurAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
