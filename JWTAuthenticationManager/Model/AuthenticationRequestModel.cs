using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationManager.Model
{
    public class AuthenticationRequestModel
    {
        //users are only required to provide username and password to login
        //of course you can ask them to provide more info according to needs
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
