using System;
using System.Collections.Generic;
using System.Text;

namespace FilmSheet.Models
{
    [Serializable]
    public class Peliculas : Recurso
    {
        public int duracion { get; set; }
        public string genero { get; set; }

        public override string ToString()
        {
            return $"{base.titulo} - {base.author}";
        }

    }
}
