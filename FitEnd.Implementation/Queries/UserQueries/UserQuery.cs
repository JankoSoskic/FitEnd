using FitEnd.Application.Dto.UsersDto;
using FitEnd.Application.Queries.UserQueries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries.UserQueries
{
    public class UserQuery : IUserQuery
    {
        private readonly Context context;

        public UserQuery(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 16;

        public string NameUseCase => "Search for users";

        public IEnumerable<UsersDto> Izvrsi(string pretraga)
        {
            //jos jedan ternari operator
            var Users = !String.IsNullOrWhiteSpace(pretraga) ? this.context.Users.Where(x => (x.Ime.ToLower().Contains(pretraga.ToLower()) || x.Prezime.ToLower().Contains(pretraga.ToLower()))).Select(x=> new UsersDto() 
            {
                 Id = x.Id,
                NazivUloge = x.Role.Name,
                Email = x.Email,
                Ime = x.Ime,
                Prezime = x.Prezime,
            }).ToList() : this.context.Users.Select(x => new UsersDto()
            {
                Id = x.Id,
                NazivUloge = x.Role.Name,
                Email = x.Email,
                Ime = x.Ime,
                Prezime = x.Prezime,

            }).ToList();
            return Users;
        }
    }
}
