using Gestion_NSA.Models;


namespace Gestion_NSA.Services
{
    public interface IPaiementService
    {
        Task<IEnumerable<Paiement>> GetAllPaiementsAsync();
        Task<Paiement> GetPaiementByIdAsync(int id);
        Task AddPaiementAsync(Paiement paiement);
        Task UpdatePaiementAsync(Paiement paiement);
        Task DeletePaiementAsync(int id);
    }
}
