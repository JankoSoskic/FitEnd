using FitEnd.Application.Exceptions;
using FitEnd.Implementation.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate sledeciZadatak;

        public GlobalExceptionHandler(RequestDelegate sledeciZadatak)
        {
            this.sledeciZadatak = sledeciZadatak;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await sledeciZadatak(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object odgovor = null;
                var statusniKod = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case NePronadjeniObjekatException obj:
                        statusniKod = StatusCodes.Status404NotFound;
                        odgovor = new
                        {
                            poruka = obj.Message
                        };
                    break;
                    case FluentValidation.ValidationException obj:
                        statusniKod = StatusCodes.Status422UnprocessableEntity;
                        odgovor = obj.Errors.Select(x => new
                        {
                            x.PropertyName,
                            x.ErrorMessage
                        });
                    break;
                    case KonfliktniObjekatExcpetion obj:
                        statusniKod = StatusCodes.Status409Conflict;
                        odgovor = new
                        {
                            poruka = obj.Message
                        };
                    break;
                    case NeDozvoljeniPristupException obj:
                        statusniKod = StatusCodes.Status401Unauthorized;
                        odgovor = new
                        {
                            poruka = obj.Message
                        };
                    break;
                    case NeUspesnoLogovanjeExcpetion obj: //Samo zbog odgovarajuce poruke ovaj excpetion
                        statusniKod = StatusCodes.Status404NotFound;
                        odgovor = new
                        {
                            poruka = obj.Message
                        };
                    break;
                    case Exception obj: // ovo posle izbrisati
                        statusniKod = StatusCodes.Status500InternalServerError;
                        odgovor = new
                        {
                            poruka = obj.Message
                        };
                    break;
                }
                httpContext.Response.StatusCode = statusniKod;
                if(odgovor != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(odgovor));
                    return;
                }
                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
