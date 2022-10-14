using DomainClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsServices.DTOs.Users
{
    public class UserDto
    {        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
    }
}
