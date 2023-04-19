using Microsoft.EntityFrameworkCore;
using Simple.API.Data;
using Simple.API.Domain;
using Simple.API.Exceptions;
using Simple.API.Interfaces;

namespace Simple.API.Services;

public class ClientRepository: IClientRepository
{
    private readonly ClientDbContext _context;
    public ClientRepository(ClientDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Client>> GetClients()
    {
        return await _context.Client.ToListAsync();
    }

    public async Task<Client> GetClient(int id)
    {
        var client = await _context.Client.FindAsync(id);
        if (client is null)
        {
            throw new NotFoundException($"Entity Product with Id: ({id}) was not found.");
        }

        return client;
    }

    public async Task CreateClient(Client client)
    {
        await _context.Client.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task<Client> UpdateClient(Client client)
    {
        
        if (!IsClientExisted(client.Id))
        {
            throw new NotFoundException($"Entity Product with Id: ({client.Id}) was not found.");
        }
        
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return client;
    }

    public async Task DeleteClient(int id)
    {
        var clientEntity = await GetClient(id);
        if (clientEntity is null)
        {
            throw new NotFoundException($"Entity Client with Id: ({id}) was not found.");
        }

        _context.Client.Remove(clientEntity);
        await _context.SaveChangesAsync();
    }

    private bool IsClientExisted(int id)
    {
        return  _context.Client.Any(x => x.Id == id);
    }
}