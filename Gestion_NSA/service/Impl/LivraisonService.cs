using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services.Impl
{
    public class LivraisonService : ILivraisonService
    {
        private readonly ApplicationDbContext _context;

        public LivraisonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livraison>> GetAllLivraisonsAsync()
        {
            return await _context.Livraisons
                .Include(l => l.Livreur)
                .Include(l => l.Commande)
                .ToListAsync();
        }

        public async Task<Livraison> GetLivraisonByIdAsync(int id)
        {
            return await _context.Livraisons
                .Include(l => l.Livreur)
                .Include(l => l.Commande)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddLivraisonAsync(Livraison livraison)
        {
            await _context.Livraisons.AddAsync(livraison);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivraisonAsync(Livraison livraison)
        {
            _context.Livraisons.Update(livraison);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivraisonAsync(int id)
        {
            var livraison = await _context.Livraisons.FindAsync(id);
            if (livraison != null)
            {
                _context.Livraisons.Remove(livraison);
                await _context.SaveChangesAsync();
            }
        }
    }
}
