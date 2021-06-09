using FitEnd.Application.Dto.UsersDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Queries.UserQueries
{
    public interface IRolesQuery : IQuery<object,IEnumerable<RolesDto>>
    {
    }
}
