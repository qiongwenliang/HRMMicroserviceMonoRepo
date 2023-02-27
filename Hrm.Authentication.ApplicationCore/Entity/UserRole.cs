using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Authentication.ApplicationCore.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        //navigational property
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
