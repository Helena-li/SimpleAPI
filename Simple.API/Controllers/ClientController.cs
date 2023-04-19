using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Simple.API.Exceptions;
using Simple.API.Interfaces;
using Simple.API.Models;

namespace Simple.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ILogger<ClientController> _logger;
    private IValidator<ClientModel> _validator;
    
    public ClientController(IClientService clientService, ILogger<ClientController> logger, IValidator<ClientModel> validator)
    {
        _clientService = clientService;
        _logger = logger;
        _validator = validator;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        _logger.LogInformation("GetClients at: {time}", DateTimeOffset.UtcNow);
        return Ok(await _clientService.GetClients()) ;
    }
    
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetClient(int id)
    {
        return Ok(await _clientService.GetClient(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostClient(ClientModel client)
    {
        var result = await _validator.ValidateAsync(client);
        if (!result.IsValid)
        {
            throw new Simple.API.Exceptions.ValidationException(result.Errors);
        }
        await _clientService.CreateClient(client);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> PutClient(ClientModel client)
    {
        return Ok(await _clientService.UpdateClient(client));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    { 
        await _clientService.DeleteClient(id);
        return Ok();
    }
}