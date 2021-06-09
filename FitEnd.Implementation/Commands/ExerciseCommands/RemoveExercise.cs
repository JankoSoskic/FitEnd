using FitEnd.Application.Commands;
using FitEnd.Application.Exceptions;
using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Commands
{
    public class RemoveExercise : IRemoveExercise
    {
        private readonly Context context;
        private readonly IPrebacivacSlika prebacivac;

        public RemoveExercise(Context context, IPrebacivacSlika prebacivac)
        {
            this.context = context;
            this.prebacivac = prebacivac;
        }

        public int IdUseCase => 5;

        public string NameUseCase => "Remove exercise";

        public void Izvrsi(int zahtev)
        {
            var vezba = this.context.Exercises.Find(zahtev);
            if(vezba == null)
            {
                throw new NePronadjeniObjekatException(zahtev);
            }
            if(this.context.PlanDetails.Any(x=>x.IdExercise == zahtev))
            {
                throw new KonfliktniObjekatExcpetion(zahtev);
            }
            var obj = this.context.Exercises.Find(zahtev);
            var slike = this.context.ExercisePictures.Where(x => x.IdExercise == zahtev);
           
            foreach(var slika in slike)
            {
                slika.DeletedAt = DateTime.UtcNow;
                slika.IsDeleted = true;
            }
            obj.DeletedAt = DateTime.UtcNow;
            obj.IsDeleted = true;
            this.context.SaveChanges();
        }
    }
}
