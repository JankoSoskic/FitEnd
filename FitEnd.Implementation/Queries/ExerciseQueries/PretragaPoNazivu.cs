using FitEnd.Application.Dto;
using FitEnd.Application.Queries.ExerciseQueries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries.ExerciseQueries
{
    public class PretragaPoNazivu : IPretragaPoNazivu
    {
        private readonly Context context;

        public PretragaPoNazivu(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 14;

        public string NameUseCase => "Search exercise by its Name";

        public IEnumerable<ExerciseDto> Izvrsi(string pretraga)
        {
            var objekti = this.context.Exercises.Where(x => x.Naziv.ToLower().Contains(pretraga.ToLower())).Select(x => new ExerciseDto()
            {
                Name = x.Naziv,
                AverageCalLost = x.AverageCalLost,
                Description = x.Description,
                ExerciseType = x.ExerciseType.Name,
                IdExercise = x.Id,
                Alts = x.ExercisePics.Select(x => x.Alt),
                PicSrcs = x.ExercisePics.Select(x => x.Src)
            }).ToList();
            return objekti;
        }
    }
}
