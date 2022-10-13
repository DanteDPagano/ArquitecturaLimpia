using DomainClass.Common;

namespace DomainClass.Entity
{
    public class UserSystem : BaseEntity
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public long UserRol { get; set; }
        
    }
}
