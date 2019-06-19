using Common.Enums;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Bo;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SecurityService: ISecurityService
    {

        private readonly MyContext _myContext;
        private readonly IConfiguration configuration;

        public SecurityService(MyContext myContext,IConfiguration Configuration) {

            _myContext = myContext;
            configuration = Configuration;
        }

        public async Task<AuthResponseBo> authentication(LoginBo loginBo) {

            var result = await _myContext.User.AsNoTracking().FirstOrDefaultAsync(w => w.Username == loginBo.Username && w.Password == loginBo.Password && w.RecordStatus == RecordStatus.Active);
            if (result != null)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub,result.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName,result.Username),
                        new Claim("isAdmin",result.IsAdmin.ToString()),
                    };

                var token = new JwtSecurityToken(
                    configuration["Tokens:Issuer"],
                    configuration["Tokens:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: credentials
                    );

                var generatedToken = new AuthResponseBo
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenExpiration = token.ValidTo,
                    IsAdmin = result.IsAdmin
                };

                return generatedToken;
            }
            return new AuthResponseBo();

        }
    }
}
