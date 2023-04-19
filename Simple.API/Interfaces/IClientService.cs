using Simple.API.Domain;
using Simple.API.Models;

namespace Simple.API.Interfaces;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClients();
    Task<Client> GetClient(int id);
    Task CreateClient(ClientModel client);
    Task<Client> UpdateClient(ClientModel client);
    Task DeleteClient(int id);
}