using Digital_Domain_Layer.Entities;
using Digital_Infrastructure_Layer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Digital_Infrastructure_Layer.Extensions
{
    public static class HandleTokenValidator
    {
        public static async Task<TokenModel> HandleToken(IList<string> roles,User user,string secretKey)
        {
            TokenModel tokenInstance = new();
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier,user.Id),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name,user.Email)
            };
            claims.AddRange(roles.Select(role => new System.Security.Claims.Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            
            tokenInstance.Token = tokenHandler.WriteToken(token);
            tokenInstance.Expiration = tokenDescriptor.Expires.Value;

            return tokenInstance;


        }

    }
}
