using FitEnd.Application;
using FitEnd.Application.Actors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FitEnd.Implementation.Loggers
{
    public class TextFileLogger : ILogger
    {
        public void loging(IAppActor actor, IUseCase useCase, object obj)
        {
            var textUpis = $"{DateTime.Now}__||__{actor.Identity}__||__{useCase.NameUseCase}__||__{JsonConvert.SerializeObject(obj)}";
           
            var putanja = Path.Combine("wwwroot", "Logs", "logs.txt");
            using (var fs = File.AppendText(putanja))
            {
                fs.WriteLine(textUpis);
            }

        }
    }
}
