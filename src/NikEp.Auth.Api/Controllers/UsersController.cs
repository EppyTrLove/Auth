using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NikEp.Auth.Application.Users;
using NikEp.Auth.Contracts;
using NikEp.Auth.Domain.Entities;
using NikEp.Auth.Persistence;

namespace NikEp.Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(
    RegisterUserHandler registerUserHandler,
    EditUserHandler editUserHandler,
    AuthDbContext context
) : ControllerBase
{
    [HttpPost("[action]")]
    public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
    {
        var user = await registerUserHandler.Execute(request);
        return new RegisterUserResponse(user.Id);
    }

    [HttpPost("[action]")]
    public async Task Edit(EditUserRequest request)
    {
        await editUserHandler.Execute(request);
    }
    
    [HttpGet("[action]/{id}")]
    public async Task<UserResponse?> Get(Guid id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return null;
        return new UserResponse(user.Id, user.Name.FirstName, user.Name.LastName, user.Email._email, user.PhoneNumber._phoneNumber);
    }
    
    [HttpGet("[action]")]
    public async Task<User[]> Get()
    {
        return await context.Users.ToArrayAsync();
    }
}