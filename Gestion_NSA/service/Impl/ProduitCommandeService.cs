using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services
{
    public class ProduitCommandeService : IProduitCommandeService
    {
        private readonly ApplicationDbContext _context;

        public ProduitCommandeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProduitCommande>> GetAllProduitCommandesAsync()
        {
            return await _context.ProduitCommandes
                                 .Include(pc => pc.Commande)
                                 .Include(pc => pc.Produit)
                                 .ToListAsync();
        }

        public async Task<ProduitCommande> GetProduitCommandeByIdAsync(int commandeId, int produitId)
        {
            return await _context.ProduitCommandes
                                 .Include(pc => pc.Commande)
                                 .Include(pc => pc.Produit)
                                 .FirstOrDefaultAsync(pc => pc.CommandeId == commandeId && pc.ProduitId == produitId);
        }

        public async Task AddProduitCommandeAsync(ProduitCommande produitCommande)
        {
            await _context.ProduitCommandes.AddAsync(produitCommande);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduitCommandeAsync(ProduitCommande produitCommande)
        {
            _context.ProduitCommandes.Update(produitCommande);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitCommandeAsync(int commandeId, int produitId)
        {
            var produitCommande = await _context.ProduitCommandes.FirstOrDefaultAsync(pc => pc.CommandeId == commandeId && pc.ProduitId == produitId);
            if (produitCommande != null)
            {
                _context.ProduitCommandes.Remove(produitCommande);
                await _context.SaveChangesAsync();
            }
        }
    }
} 