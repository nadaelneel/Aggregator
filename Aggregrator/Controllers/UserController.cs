using Aggregrator.IGService;
using Microsoft.AspNetCore.Mvc;
using Aggregrator.Services.User.DTO;
using UserApp.Application;

namespace Aggregrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<int> Add(CreateUserRequestDto create)
        {
            return await userService.create(create);
        }
    }
}
