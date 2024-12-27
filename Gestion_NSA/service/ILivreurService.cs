using Gestion_NSA.Models;

namespace Gestion_NSA.Services
{
    public interface ILivreurService
    {
        Task<IEnumerable<Livreur>> GetAllLivreursAsync();
        Task<Livreur> GetLivreurByIdAsync(int id);
        Task AddLivreurAsync(Livreur livreur);
        Task UpdateLivreurAsync(Livreur livreur);
        Task DeleteLivreurAsync(int id);
    }
}
