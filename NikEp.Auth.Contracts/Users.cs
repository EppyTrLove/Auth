namespace NikEp.Auth.Contracts;


    public record RegisterUserRequest(string FirstName, string LastName, string Email, string PhoneNumber,
        string Password, DateTime Birthday );
    public class RegisterUserResponse(string Id);
