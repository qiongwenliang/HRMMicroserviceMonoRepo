using JWTAuthenticationManager.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_Secret_key = "IamUsingThisKeyAsJWTSecretKeyForSecurityin2023YearMonth03";
        public const int JWT_Token_Valid_Mins = 20;

        private readonly List<UserAccount> accounts;

        public JwtTokenHandler()
        {
            accounts = new List<UserAccount>()
            {
                //below are hard coded userAccount values
                new UserAccount() { Username="admin", Password="admin@1234", Role="Admin" },
                new UserAccount() { Username="betty", Password="betty@1234", Role="User" },
                new UserAccount() { Username="scott", Password="scott@1234", Role="Manager" }
            };
        }


        //here this method is to return a AuthenticationResponseModel, and its purpose
        //is to get the token from the logged in information passed by users
        public AuthenticationResponseModel GenerateJwtToken(AuthenticationRequestModel authenticationRequestModel)
        {
            if (authenticationRequestModel == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(authenticationRequestModel.Username) || string.IsNullOrEmpty(authenticationRequestModel.Password))
            {
                return null;
            }

            var accountInfo = accounts.Where(x => x.Username == authenticationRequestModel.Username && x.Password == authenticationRequestModel.Password).FirstOrDefault();
            if (accountInfo == null) return null;

            //after checing the account and password are valid, ready to generate jwt token
            //codes for jwt token generation below

            //1.time
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_Token_Valid_Mins);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_Secret_key);


            //2. this is to identify different users
            var claimsUserIdentity = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, authenticationRequestModel.Username),
                    new Claim(ClaimTypes.Role, accountInfo.Role)
                });

             
            //3. here is to convert our secret key into encrypted value
            var signInCredentials = new SigningCredentials(
                //this is to create security key and it only takes byte value
                new SymmetricSecurityKey(tokenKey), 
                //these are the algorithms to get encrypted, and it's up to you choose whatever
                SecurityAlgorithms.HmacSha256Signature
                );

            //now use the above 3 objects and connect them together
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                //here is to bind the 3 object into 1 object
                Subject = claimsUserIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signInCredentials
            };


            //to create token here, this handler will help us to do this
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            //this writeToken turn token into string form, so that will be correspondence to our token return type
            var tokenString = jwtSecurityTokenHandler.WriteToken(securityToken);


            return new AuthenticationResponseModel
            {
                UserName = authenticationRequestModel.Username,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = tokenString
            };


        }
    }
}
