using System;
using System.Collections.Generic;
using System.Text;

namespace FilmSheet.Models
{
    [Serializable]
    public class Recurso
    {
        public string titulo { get; set; }
        public string author { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public string sinopsis { get; set; }
        public bool prestado { get; set; }
        public string ImageUrl { get; set; }

        public DateTime fechaDevolucion { get; set; }
        public DateTime fechaPrestado { get; set; }

        public override string ToString()
        {
            return $"Nombre: {titulo} con autor: {author} fue publicado {fechaPublicacion}";
        }
    }
}
