using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
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
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("Error en el Id suministrado no corresponde al registro a actualizar");
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {           
            return Ok(await Mediator.Send(id));
        }
    }
}
