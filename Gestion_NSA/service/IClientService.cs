
using Gestion_NSA.Models;

namespace Gestion_NSA.Services;
public interface IClientService{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> Create(Client client);
    

    }