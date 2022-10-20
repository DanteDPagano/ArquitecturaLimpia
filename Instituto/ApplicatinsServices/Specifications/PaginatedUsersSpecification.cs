using ApplicationsServices.Filters;
using Ardalis.Specification;
using DomainClass.Entity;

namespace ApplicationsServices.Specifications
{
    internal class PaginatedUsersSpecification : Specification<UserSystem>
    {
        public PaginatedUsersSpecification(UserResponseFilter filter)
        {
           
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
            
            if (!String.IsNullOrEmpty(filter.Name))
                Query.Search(x => x.Name, "%" + filter.Name + "%");

            if(!String.IsNullOrEmpty(filter.LastName))
                Query.Search(x => x.LastName, "%" + filter.LastName + "%");

        }
    }
}
