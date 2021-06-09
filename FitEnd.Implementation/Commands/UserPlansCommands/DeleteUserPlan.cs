using FitEnd.Application.Commands.UserPlanCommands;
using FitEnd.Application.Exceptions;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Commands.UserPlansCommands
{
    public class DeleteUserPlan : IDeleteUserPlan
    {
        private readonly Context context;

        public DeleteUserPlan(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 13;

        public string NameUseCase => "Delete user plan";

        public void Izvrsi(int zahtev)
        {
            var plan = this.context.UserPlans.Find(zahtev);
            if(plan == null)
            {
                throw new NePronadjeniObjekatException(zahtev);
            }
            var planDetails = this.context.PlanDetails.Where(x => x.IdPlan == zahtev);
            this.context.PlanDetails.RemoveRange(planDetails);
            plan.DeletedAt = DateTime.UtcNow;
            plan.IsDeleted = true;
            this.context.SaveChanges();
        }
    }
}
