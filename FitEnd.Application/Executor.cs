using FitEnd.Application.Actors;
using FitEnd.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Application
{
    public class Executor
    {
        private readonly ILogger loger;
        private readonly IAppActor actor;
        public Executor(ILogger loger, IAppActor actor)
        {
            this.loger = loger;
            this.actor = actor;
        }

        public void IzvrsiKomandu<Komanda>(ICommand<Komanda> komanda,Komanda req)
        {
            this.loger.loging(this.actor, komanda, req);
            if (!actor.AllowedActions.Any(x => x == komanda.IdUseCase))
            {
                throw new NeDozvoljeniPristupException(komanda.NameUseCase);
            }
            komanda.Izvrsi(req);
        }
        public rezultat IzvrsiQuery<pretraga,rezultat>(IQuery<pretraga,rezultat> upit, pretraga search)
        {
            this.loger.loging(this.actor, upit, search);

            if (!actor.AllowedActions.Any(x=>x == upit.IdUseCase))
            {
                throw new NeDozvoljeniPristupException(upit.NameUseCase);
            }
            
            return upit.Izvrsi(search);
        }
    }
}
