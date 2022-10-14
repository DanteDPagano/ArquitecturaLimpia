using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectUserByIdQuery : IRequest<Response<UserDto>>
    {
        public long Id { get; set; }
    }
    public class SelectUserByIdQueryHandler : IRequestHandler<SelectUserByIdQuery, Response<UserDto>>
    {
        private readonly IRepository<UserSystem> _repository;
        private readonly IMapper _mapper;

        public SelectUserByIdQueryHandler(IRepository<UserSystem> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<UserDto>> IRequestHandler<SelectUserByIdQuery, Response<UserDto>>.Handle(SelectUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if(user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<UserDto>(user);
                return new Response<UserDto>(dto);

            }
        }
    }
    
}
