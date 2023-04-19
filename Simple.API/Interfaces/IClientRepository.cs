using Simple.API.Domain;

namespace Simple.API.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClients();
    Task<Client> GetClient(int id);
    Task CreateClient(Client client);
    Task<Client> UpdateClient(Client client);
    Task DeleteClient(int id);
}