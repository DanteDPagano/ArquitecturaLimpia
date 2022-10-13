using ApplicationsServices.Features.Commands.CreateCommands;
using ApplicationsServices.Features.Commands.UpdateCommands;
using AutoMapper;
using DomainClass.Entity;

namespace ApplicationsServices.Mapping
{
    public class GeneralMaping : Profile
    {
        public GeneralMaping()
        {
            CreateMap<CreateUserCommand, UserSystem>();
        }
    }
}
