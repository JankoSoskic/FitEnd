using FitEnd.Application.Exceptions;
using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public class JwtAction
    {
        private readonly Context context;
        private readonly IEncodePassword enkoder;
        private readonly string issuer;
        private readonly string tajniKljuc;

        public JwtAction(Context context,IEncodePassword enkoder)
        {
            this.issuer = Config.JWTIssuer;
            this.tajniKljuc = Config.TajniJWTKljuc;
            this.context = context;
            this.enkoder = enkoder;
        }

        public string PraviToken(string username,string password)
        {
            var actorr = this.context.Users.Where(x => (x.Username == username && x.Password == this.enkoder.EnkodujPassword(password))).Select(x => new JwtActor()
            {
                Id = x.Id,
                Identity = x.Ime + " " + x.Prezime + $"({x.Username})",
                AllowedActions = x.Role.AllowedUseCase.Where(t => t.IdRole == x.IdUloge).Select(m => m.IdUseCase)
            }).ToList();
            


            if(actorr.Count() != 1)
            {
                throw new NeUspesnoLogovanjeExcpetion();
            }
            var actor = actorr.First();
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, this.issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, this.issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, this.issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, this.issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, this.issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.tajniKljuc));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
