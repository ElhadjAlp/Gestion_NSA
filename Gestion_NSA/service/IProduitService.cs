using Gestion_NSA.Models;


namespace Gestion_NSA.Services
{
    public interface IProduitService
    {
        Task<IEnumerable<Produit>> GetAllProduitsAsync();
        Task<Produit> GetProduitByIdAsync(int id);
        Task AddProduitAsync(Produit produit);
        Task UpdateProduitAsync(Produit produit);
        Task DeleteProduitAsync(int id);
    }
}
