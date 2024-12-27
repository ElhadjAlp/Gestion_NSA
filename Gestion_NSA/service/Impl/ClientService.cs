using Gestion_NSA.Data;
using Gestion_NSA.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_NSA.Services.Impl;
public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client> Create(Client client)
    {

        _context.Clients.Add(client);

        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        // Your implementation to fetch clients from your data source
        return await _context.Clients.ToListAsync();
    }

}
 
