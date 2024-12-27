using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;


namespace Gestion_NSA.Services
{
    public class CommandeService : ICommandeService
    {
        private readonly ApplicationDbContext _context;

        public CommandeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commande>> GetAllCommandesAsync()
        {
            return await _context.Commandes
                                 .Include(c => c.Client) // Inclure les relations si nécessaire
                                 .ToListAsync();
        }

        public async Task<Commande> GetCommandeByIdAsync(int id)
        {
            return await _context.Commandes
                                 .Include(c => c.Client) // Inclure les relations si nécessaire
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCommandeAsync(Commande commande)
        {
            await _context.Commandes.AddAsync(commande);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommandeAsync(Commande commande)
        {
            _context.Commandes.Update(commande);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommandeAsync(int id)
        {
            var commande = await _context.Commandes.FirstOrDefaultAsync(c => c.Id == id);
            if (commande != null)
            {
                _context.Commandes.Remove(commande);
                await _context.SaveChangesAsync();
            }
        }
    }
}
