using FluentValidation;
using Simple.API.Domain;
using Simple.API.Interfaces;
using Simple.API.Models;

namespace Simple.API.Services;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    public Task<IEnumerable<Client>> GetClients()
    {
        return _clientRepository.GetClients();
    }

    public Task<Client> GetClient(int id)
    {
        return _clientRepository.GetClient(id);
    }

    public Task CreateClient(ClientModel client)
    {
        var clientDto = MapClient(client);
        return _clientRepository.CreateClient(clientDto);
    }

    public Task<Client> UpdateClient(ClientModel client)
    {
        var clientDto = MapClient(client);
        return _clientRepository.UpdateClient(clientDto);
    }

    public Task DeleteClient(int id)
    {
        return _clientRepository.DeleteClient(id);
    }

    public Client MapClient(ClientModel client)
    {
        return new Client()
        {
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            DateBecameCustomer = client.DateBecameCustomer,
        };
    }
}