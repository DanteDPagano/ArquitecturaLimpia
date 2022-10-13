using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteUserCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeleteUserCommandHandle : IRequestHandler<DeleteUserCommand, Response<long>>
    {
        private readonly IRepository<UserSystem> _repository;

        public DeleteUserCommandHandle(IRepository<UserSystem> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
            }
            else
            { 
                await _repository.DeleteAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
