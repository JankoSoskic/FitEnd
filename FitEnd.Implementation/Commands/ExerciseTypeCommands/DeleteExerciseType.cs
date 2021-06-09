using FitEnd.Application.Commands.ExerciseTypeCommands;
using FitEnd.Application.Exceptions;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Commands.ExerciseTypeCommands
{
    public class DeleteExerciseType :  IDeleteExerciseType
    {
        private readonly Context context;
        public DeleteExerciseType(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 9;

        public string NameUseCase => "Deleteing Exercise type";

        public void Izvrsi(int zahtev)
        {
            var obj = this.context.ExerciseTypes.Find(zahtev);
            if(obj == null)
            {
                throw new NePronadjeniObjekatException(zahtev);
            }
            if (this.context.Exercises.Any(x => x.IdType == zahtev))
            {
                throw new KonfliktniObjekatExcpetion(zahtev);
            }
            obj.IsDeleted = true;
            obj.DeletedAt = DateTime.UtcNow;
            this.context.SaveChanges();
        }
    }
}
