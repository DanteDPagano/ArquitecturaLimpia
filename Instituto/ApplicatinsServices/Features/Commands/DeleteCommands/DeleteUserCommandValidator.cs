using ApplicationsServices.Features.Commands.UpdateCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x =>x.Id).NotEmpty().NotNull();
        }
    }
}
