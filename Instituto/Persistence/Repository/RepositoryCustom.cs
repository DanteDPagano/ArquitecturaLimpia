using Ardalis.Specification.EntityFrameworkCore;
using ApplicationsServices.Interfaces;
using Persistence.Contexts;
using DomainClass.Common;

namespace Persistence.Repository
{
    internal class RepositoryCustom<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        private readonly InstituteAppContext _context;

        public RepositoryCustom(InstituteAppContext context) :base(context)
        {
            _context = context;
        }
    }
}
