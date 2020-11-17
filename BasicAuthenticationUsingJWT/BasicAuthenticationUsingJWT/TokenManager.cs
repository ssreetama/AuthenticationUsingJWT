using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BasicAuthenticationUsingJWT
{
    public class TokenManager
    {
        private static string Secret = "Sreetama Sarkar is very bad girl";
        public static string Token = "Chepikaa";
        public static ClaimsPrincipal GetPricipal(string Token)
        {
            try 
            {
                JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenhandler.ReadJwtToken(Token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Secret)));

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenhandler.ValidateToken(Token, parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                String m = e.Message;
                return null;
            }

        }
        public static string ValiadateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principle = GetPricipal(token);
            if (principle == null)
                return null;

            try
            {
          
                 var list = principle.Claims.ToList();
                foreach( var j in list)
                {
                    Console.WriteLine(j.Type + " " + j.Value);
                    if (j.Type.Equals("name"))
                        return j.Value;
                }
                return null;


            }
            catch(NullReferenceException)
            {
                return null;
            }
            


            return null; ;
        }
    }
}