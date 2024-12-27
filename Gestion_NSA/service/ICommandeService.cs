using Gestion_NSA.Models;


namespace Gestion_NSA.Services
{
    public interface ICommandeService
    {
        Task<IEnumerable<Commande>> GetAllCommandesAsync();
        Task<Commande> GetCommandeByIdAsync(int id);
        Task AddCommandeAsync(Commande commande);
        Task UpdateCommandeAsync(Commande commande);
        Task DeleteCommandeAsync(int id);
    }
}
