
using FitEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.GenericActions
{
    public interface IPrebacivacSlika
    {
        public IEnumerable<string> prebaciSliku(IEnumerable<IFormFile> slike);
        public void izbrisiSlike(IEnumerable<ExercisePictures> slikePutanja);
    }
}
