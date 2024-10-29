using NikEp.Auth.Contracts;
using NikEp.Auth.Domain.Entities;
using NikEp.Auth.Domain.ValueObjects;
using NikEp.Auth.Persistence;

namespace NikEp.Auth.Application.Users;

public class RegisterUserHandler(AuthDbContext context)
{
    public async Task<User> Execute(RegisterUserRequest request)
    {
        var name = new Name(request.FirstName, request.LastName);
        var email = new Email(request.email);
        var phoneNumber = new PhoneNumber(request.number);
        var user = new User(name, email, phoneNumber);
        
        await context.AddAsync(user);
        await context.SaveChangesAsync();
        
        return user;
    }
}