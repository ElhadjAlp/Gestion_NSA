using Gestion_NSA.Models;
using Gestion_NSA.Services;
using Microsoft.AspNetCore.Mvc;


namespace Gestion_NSA.Controllers
{
    public class PaiementController : Controller
    {
        private readonly IPaiementService _paiementService;

        public PaiementController(IPaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        public async Task<IActionResult> Index()
        {
            var paiements = await _paiementService.GetAllPaiementsAsync();
            return View(paiements);
        }

        public async Task<IActionResult> Details(int id)
        {
            var paiement = await _paiementService.GetPaiementByIdAsync(id);
            if (paiement == null)
                return NotFound();

            return View(paiement);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paiement paiement)
        {
            if (ModelState.IsValid)
            {
                await _paiementService.AddPaiementAsync(paiement);
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var paiement = await _paiementService.GetPaiementByIdAsync(id);
            if (paiement == null)
                return NotFound();

            return View(paiement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paiement paiement)
        {
            if (id != paiement.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _paiementService.UpdatePaiementAsync(paiement);
                return RedirectToAction(nameof(Index));
            }
            return View(paiement);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var paiement = await _paiementService.GetPaiementByIdAsync(id);
            if (paiement == null)
                return NotFound();

            return View(paiement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paiementService.DeletePaiementAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
