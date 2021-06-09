using FitEnd.Application.Actors;
using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application
{
    public interface ILogger
    {
        public void loging(IAppActor actor, IUseCase useCase, object obj);
    }
}
