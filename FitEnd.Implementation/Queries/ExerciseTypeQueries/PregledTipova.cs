using FitEnd.Application;
using FitEnd.Application.Dto;
using FitEnd.Application.Queries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries
{
    public class PregledTipova : IPregledTipova
    {
        private readonly Context context;

        public PregledTipova(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 6;

        public string NameUseCase => "Getting every single Exercise type";

        public ICollection<SviTipoviDto> Izvrsi(object pretraga)
        {
            var vezbe = this.context.ExerciseTypes.Select(x => new SviTipoviDto()
            {
                IdType = x.Id,
                Name = x.Name
            }).ToList();
            return vezbe;
        }
    }
}
