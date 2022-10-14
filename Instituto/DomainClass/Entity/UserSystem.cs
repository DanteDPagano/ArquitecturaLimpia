using DomainClass.Common;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DomainClass.Entity
{
    public class UserSystem : BaseEntity
    {
        private string _password;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get { return _password; } set { _password = value.Encriptar(); } }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public long UserRol { get; set; }
        
    }
}
