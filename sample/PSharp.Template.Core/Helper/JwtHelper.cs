using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Util.Security.Claims;
using PSharp.Template.Core.Dependency;
using PSharp.Template.Core.Options;
using IdentityModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PSharp.Template.Core.Helper
{
    public class JwtHelper : IIScopeDependency
    {
        private readonly JwtOptions _jwtOptions;
        public JwtHelper(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string IssueJwt(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: claims),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_jwtOptions.Lifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
