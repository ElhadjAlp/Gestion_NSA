using Gestion_NSA.Models;

namespace Gestion_NSA.Services
{
    public interface IProduitCommandeService
    {
        Task<IEnumerable<ProduitCommande>> GetAllProduitCommandesAsync();

        Task<ProduitCommande> GetProduitCommandeByIdAsync(int commandeId, int produitId);

        Task AddProduitCommandeAsync(ProduitCommande produitCommande);

        Task UpdateProduitCommandeAsync(ProduitCommande produitCommande);

        Task DeleteProduitCommandeAsync(int commandeId, int produitId);
    }
}
