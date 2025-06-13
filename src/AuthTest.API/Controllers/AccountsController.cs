using AuthTest.API.DTO;
using AuthTest.API.Exceptions;
using AuthTest.API.Models;
using AuthTest.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTest.API.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IAccountsService _service;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(IAccountsService service, ILogger<AccountsController> logger)
    {
        _logger = logger;
        _service = service;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAccounts>>> GetAllAccounts(CancellationToken cancellationToken)
    {
        try
        {
            List<GetAccounts> accounts = await _service.GetAccountsAsync(cancellationToken);
            return Ok(accounts);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem();
        }
    }
    
    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<GetAccounts>>> GetAccountById(int id, CancellationToken cancellationToken)
    {
        var currentUsername = User.Identity.Name;
        var currentUserAccount = await _service.GetAccountByUsernameAsync(currentUsername, cancellationToken);
        if (currentUserAccount.Role != "Admin" && currentUserAccount.Id != id) return Forbid();
        try
        {
            GetAccount? account = await _service.GetAccountByIdAsync(id, cancellationToken);
            return account != null ? Ok(account) : NotFound($"User with id {id} not found");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem();
        }
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<IEnumerable<GetAccounts>>> CreateAccount(CreateAccountDto dto, CancellationToken cancellationToken)
    {
        try
        {
            CreateAccountDto createdAccount = await _service.CreateAccount(dto, cancellationToken);
            return CreatedAtAction(nameof(GetAccountById), new { id = createdAccount.Id }, createdAccount);
        }
        catch (AlreadyExistsException e)
        {
            return Conflict(e.Message);
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Problem();
        }
    }
    
}