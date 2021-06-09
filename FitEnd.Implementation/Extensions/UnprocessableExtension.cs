using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Extensions
{
    public static class UnprocessableExtension
    {
        public static IActionResult toUnprocesable(this IEnumerable<ValidationFailure> greske)
        {
            return new UnprocessableEntityObjectResult(new
            {
                errors = greske.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                })
            });
        }
    }
}
