using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services.Impl
{
    public class PaiementService : IPaiementService
    {
        private readonly ApplicationDbContext _context;

        public PaiementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paiement>> GetAllPaiementsAsync()
        {
            return await _context.Paiements
                .Include(p => p.Client)
                .ToListAsync();
        }

        public async Task<Paiement> GetPaiementByIdAsync(int id)
        {
            return await _context.Paiements
                 .Include(p => p.Client)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPaiementAsync(Paiement paiement)
        {
            await _context.Paiements.AddAsync(paiement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaiementAsync(Paiement paiement)
        {
            _context.Paiements.Update(paiement);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaiementAsync(int id)
        {
            var paiement = await _context.Paiements.FindAsync(id);
            if (paiement != null)
            {
                _context.Paiements.Remove(paiement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
