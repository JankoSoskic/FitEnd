using FitEnd.Application.Dto;
using FitEnd.Application.GenericActions;
using FitEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FitEnd.Implementation.GenericActions
{
    public class PrebacivanjeSlika : IPrebacivacSlika
    {
        public void izbrisiSlike(IEnumerable<ExercisePictures> slikePutanja)
        {
            foreach(var slika in slikePutanja)
            {
                var putanja = Path.Combine("wwwroot", "Images", slika.Src);
                File.Delete(putanja);
            }
        }

        public IEnumerable<string> prebaciSliku(IEnumerable<IFormFile> slike)
        {
                var i = 0;
                var vreme = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                var imena = new List<string>();
                foreach (var slika in slike)
                {
                    var ekstenzija = Path.GetExtension(slika.FileName);
                    var novoIme = i.ToString() + vreme + ekstenzija;
                    var putanja = Path.Combine("wwwroot", "Images", novoIme);
                    using (var stream = new FileStream(putanja, FileMode.Create))
                    {
                        slika.CopyTo(stream);
                    }
                    imena.Add(novoIme);
                    i++;
                }
                return imena;
        }
    }
}
