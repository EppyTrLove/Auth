using Microsoft.AspNetCore.Mvc;
using NikEp.Auth.Application;
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
        public RegisterUserResponse Register(RegisterUserRequest request)
        {
            var user = _handler.Execute(request);
            return new RegisterUserResponse(user.Id.ToString());
        }

    }
}
