using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Shapes;

namespace FilmSheet.Models
{
    [Serializable]
    public class Libro : Recurso
    {
        public int numeroPaginas { get; set; }
        public string tipo { get; set; }

        public override string ToString()
        {
            return $"{base.titulo} - {base.author}";
        }
    }
}
