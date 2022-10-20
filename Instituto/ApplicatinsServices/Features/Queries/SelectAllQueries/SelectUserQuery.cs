using ApplicationsServices.DTOs.Users;
using ApplicationsServices.Filters;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
using System.Runtime.InteropServices;

namespace ApplicationsServices.Features.Queries.SelectAllQueries
{
    public class SelectUserQuery : IRequest<PaginatedResponse<IEnumerable<UserDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }

        public class SelectUserQueryHandler : IRequestHandler<SelectUserQuery, PaginatedResponse<IEnumerable<UserDto>>>
        {
            private readonly IRepository<UserSystem> _repository;
            private readonly IMapper _mapper;

            public SelectUserQueryHandler(IRepository<UserSystem> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<UserDto>>> Handle(SelectUserQuery request, CancellationToken cancellationToken)
            {
                UserResponseFilter responseFilter = new UserResponseFilter(){ PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    Name = request.Name,
                    LastName = request.LastName };

                var users = await _repository.ListAsync(new PaginatedUsersSpecification(responseFilter));
                var usersDto=_mapper.Map<IEnumerable<UserDto>>(users);
                return new PaginatedResponse<IEnumerable<UserDto>>(usersDto, request.PageNumber, request.PageSize);
            }
        }
    }
}
