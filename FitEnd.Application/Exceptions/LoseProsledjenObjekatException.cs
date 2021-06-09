using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FitEnd.Application.Exceptions
{
    public class LoseProsledjenObjekatException<nekiDto> : Exception
        where nekiDto : DtoAbstract
    {
        public LoseProsledjenObjekatException(nekiDto dto) : base($"Passed object is not valid: {JsonSerializer.Serialize(dto)} ")
        {

        }
    }
}
