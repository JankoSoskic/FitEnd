using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FitEnd.Application.Dto;
using FitEnd.Application.Pagination;
using FitEnd.Application.Queries;
using FitEnd.Application.Searches;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;

namespace FitEnd.Implementation.Queries
{
    public class UzmiVezbePaginacijom : IPregledVezba
    {
        private readonly Context context;
        
        public UzmiVezbePaginacijom(Context context)
        {
            this.context = context;
           
        }

        public int IdUseCase => 1;

        public string NameUseCase => "Search for every exercise paginated";

        public VracanjePaginacije<ExerciseDto> Izvrsi(VezbaPrazanSearch pretraga)
        {
            
            var stranicaPrepravka = pretraga.KojaStrana - 1; // iako sam mogao direktno u skip --pretraga.kojastrana stavljam ovako jer mi se vraca klijentu da je npr : 2. strana umesto 3.
            // upotreba ternarnog operatora malo zbunjujuce izgleda, ali jako korisno 
            var podaci = pretraga.IdTipaVezbe <= 0 ? this.context.Exercises.Select(x => new ExerciseDto()
            {
                 IdExercise =x.Id,
                Name = x.Naziv,
                Description = x.Description,
                AverageCalLost = x.AverageCalLost,
                ExerciseType = x.ExerciseType.Name,
                Alts = x.ExercisePics.Select(x => x.Alt),
                PicSrcs = x.ExercisePics.Select(x => x.Src)
            }).Skip(stranicaPrepravka * pretraga.PoStrani).Take(pretraga.PoStrani).ToList() :
             this.context.Exercises.Where(x=>x.IdType == pretraga.IdTipaVezbe).Select(x => new ExerciseDto()
             {

                 IdExercise = x.Id,
                 Name = x.Naziv,
                 Description = x.Description,
                 AverageCalLost = x.AverageCalLost,
                 ExerciseType = x.ExerciseType.Name,
                 Alts = x.ExercisePics.Select(x => x.Alt),
                 PicSrcs = x.ExercisePics.Select(x => x.Src)
             }).Skip(stranicaPrepravka * pretraga.PoStrani).Take(pretraga.PoStrani).ToList();
            


            var vracam = new VracanjePaginacije<ExerciseDto>()
            {
                KolikoZapisa = pretraga.IdTipaVezbe <= 0 ? this.context.Exercises.Count() : this.context.Exercises.Where(x => x.IdType == pretraga.IdTipaVezbe).Count(),
                TrenutnaStrana = pretraga.KojaStrana,
                Zapisi = podaci,
                ZapisPoStrani = pretraga.PoStrani
            };
            return vracam;
        }
    }
}
