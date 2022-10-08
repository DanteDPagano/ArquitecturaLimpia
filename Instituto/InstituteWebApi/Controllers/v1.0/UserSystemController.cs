using ApplicationsServices.Features.Commands.CreateCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstituteWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class UserSystemController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
