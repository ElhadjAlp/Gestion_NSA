using Gestion_NSA.Models;

namespace Gestion_NSA.Services
{
    public interface ILivraisonService
    {
        Task<IEnumerable<Livraison>> GetAllLivraisonsAsync();
        Task<Livraison> GetLivraisonByIdAsync(int id);
        Task AddLivraisonAsync(Livraison livraison);
        Task UpdateLivraisonAsync(Livraison livraison);
        Task DeleteLivraisonAsync(int id);
    }
}
