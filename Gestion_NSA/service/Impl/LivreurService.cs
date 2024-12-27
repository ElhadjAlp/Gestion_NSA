using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services.Impl
{
    public class LivreurService : ILivreurService
    {
        private readonly ApplicationDbContext _context;

        public LivreurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livreur>> GetAllLivreursAsync()
        {
            return await _context.Livreurs
                .Include(l => l.Livraisons)
                .ToListAsync();
        }

        public async Task<Livreur> GetLivreurByIdAsync(int id)
        {
            return await _context.Livreurs
                .Include(l => l.Livraisons)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task AddLivreurAsync(Livreur livreur)
        {
            await _context.Livreurs.AddAsync(livreur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivreurAsync(Livreur livreur)
        {
            _context.Livreurs.Update(livreur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivreurAsync(int id)
        {
            var livreur = await _context.Livreurs.FindAsync(id);
            if (livreur != null)
            {
                _context.Livreurs.Remove(livreur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
