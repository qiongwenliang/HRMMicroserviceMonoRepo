using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationManager.Model
{
    public class AuthenticationResponseModel
    {
        //when the user has been successfully logged in, we return the token to the user
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
