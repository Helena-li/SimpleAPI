using System;
using NSubstitute;
using Xunit;
using Simple.API.Domain;
using Simple.API.Interfaces;
using Simple.API.Models;
using Simple.API.Services;

namespace Simple.Api.Test;

public class ClientServiceUnitTests
{
    private readonly IClientService _service;
    private readonly IClientRepository _clientRepository;

    public ClientServiceUnitTests()
    {
        _clientRepository = Substitute.For<IClientRepository>();
        _service = new ClientService(_clientRepository);
    }

    [Fact]
    public async void ClientService_GetAll_ShouldCall_ClientRepositoryToReturnAllClients()
    {
        //Arrange

        //Act
        await _service.GetClients();

        //Assert
        await _clientRepository.Received(1).GetClients();
    }

    [Fact]
    public async void ClientServiceGetAClientById_ShouldCall_ClientRepositoryToGetTheClientById()
    {
        //Arrange
        var clientId = 1;

        //Act
        await _service.GetClient(clientId);

        //Assert
        await _clientRepository.Received(1).GetClient(clientId);
    }

    [Fact]
    public async void ClientServiceCreate_ShouldCall_ClientRepositoryToCreateANewClient()
    {
        //Arrange
        var client = new ClientModel()
        {
            Name = "Samsung Galaxy S20 Ultra",
            Email = "a@a.com",
            DateBecameCustomer = DateTime.UtcNow
        };
        //Act
        await _service.CreateClient(client);

        //Assert
        await _clientRepository.Received(1).CreateClient(Arg.Is<Client>(
            ce => ce.Id == client.Id &&
                  ce.Name == client.Name &&
                  ce.Email == client.Email &&
                  ce.DateBecameCustomer == client.DateBecameCustomer));
    }

    [Fact]
    public async void ClientServiceUpdate_ShouldCall_ClientRepositoryToUpdate()
    {
        //Arrange

        var client = new ClientModel()
        {
            Id = 1,
            Name = "Samsung Galaxy S20 Ultra",
            Email = "a@a.com",
            DateBecameCustomer = DateTime.UtcNow
        };

        //Act
        await _service.UpdateClient(client);

        //Assert
        await _clientRepository.Received(1).UpdateClient(Arg.Is<Client>(
            ce => ce.Id == client.Id &&
                  ce.Name == client.Name &&
                  ce.Email == client.Email &&
                  ce.DateBecameCustomer == client.DateBecameCustomer));
    }

    [Fact]
    public async void ClientServiceDelete_ShouldCall_ClientRepositoryToDelete()
    {
        //Arrange
        var clientId = 1;

        //Act
        await _service.DeleteClient(clientId);

        //Assert
        await _clientRepository.Received(1).DeleteClient(clientId);
    }
}