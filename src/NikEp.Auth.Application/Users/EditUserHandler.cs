using NikEp.Auth.Contracts;
using NikEp.Auth.Domain.ValueObjects;
using NikEp.Auth.Persistence;

namespace NikEp.Auth.Application.Users;

public class EditUserHandler(AuthDbContext context)
{
    public async Task Execute(EditUserRequest request)
    {
        var newName = new Name(request.FirstName, request.LastName);
        var user = await context.Users.FindAsync(request.Id);
        if (user == null)
            throw new Exception("User does not exist");
        
        user.Name = newName;
        
        await context.SaveChangesAsync();
    }
}