using NikEp.Auth.Contracts;
using NikEp.Auth.Domain.Entities;
using NikEp.Auth.Domain.ValueObjects;
using NikEp.Auth.Persistance;

namespace NikEp.Auth.Application;

    public class RegisterUserHandler
    {
    private readonly AuthDbContext _context;

    public RegisterUserHandler(AuthDbContext context)
    {
        _context = context;
    }



    public async Task<User> Execute(RegisterUserRequest request)

        {
        var user = new User(new Name(request.FirstName, request.LastName), new Email(request.Email),
            new PhoneNumber(request.PhoneNumber), request.Birthday, request.Password);
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
        }
    }

