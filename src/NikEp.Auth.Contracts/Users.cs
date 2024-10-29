using NikEp.Auth.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace NikEp.Auth.Contracts;

public record RegisterUserRequest(string FirstName, string LastName, Email email, PhoneNumber number);
public record EditUserRequest(Guid Id, string FirstName, string LastName, Email email, PhoneNumber number);
public record RegisterUserResponse(Guid Id);
