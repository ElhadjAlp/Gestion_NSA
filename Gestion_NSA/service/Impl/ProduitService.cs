using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services.Impl
{
    public class ProduitService : IProduitService
    {
        private readonly ApplicationDbContext _context;

        public ProduitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produit>> GetAllProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Produit> GetProduitByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        public async Task AddProduitAsync(Produit produit)
        {
            await _context.Produits.AddAsync(produit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduitAsync(Produit produit)
        {
            _context.Produits.Update(produit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
