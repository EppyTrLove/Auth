
namespace NikEp.Auth.Contracts;

public record RegisterUserRequest(string FirstName, string LastName, string email, string number);
public record EditUserRequest(Guid Id, string FirstName, string LastName, string email, string number);
public record UserResponse(Guid Id, string FirstName, string LastName, string email, string number);
public record RegisterUserResponse(Guid Id);
