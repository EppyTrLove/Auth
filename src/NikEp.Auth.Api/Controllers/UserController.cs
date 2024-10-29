using Microsoft.AspNetCore.Mvc;
using NikEp.Auth.Application.Users;
using NikEp.Auth.Contracts;


namespace NikEp.Auth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserstController : ControllerBase
    {
        private readonly RegisterUserHandler _handler;

        public UserstController(RegisterUserHandler handler)
        {
            _handler = handler;
        }
        [HttpPost("[action]")]
        public async Task<RegisterUserResponse> Register(RegisterUserRequest request)
        {
            var user = await _handler.Execute(request);
            return new RegisterUserResponse(user.Id);
        }

    }
}
