using FitEnd.Application.Dto.UsersDto;
using FitEnd.Application.Queries.UserQueries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries.UserQueries
{
    public class RolesQuery : IRolesQuery
    {
        private readonly Context context;

        public RolesQuery(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 18;

        public string NameUseCase => "Search for every role";

        public IEnumerable<RolesDto> Izvrsi(object pretraga)
        {
            var roles = this.context.Roles.Select(x => new RolesDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return roles;
        }
    }
}
