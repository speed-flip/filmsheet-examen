using System;
using System.Collections.Generic;
using System.Text;

namespace FilmSheet.Models
{
    [Serializable]
    public class JuegosMesa : Recurso
    {
        public int edad { get; set; }
        public int minJugadores { get; set; }
        public int maxJugadores { get; set; }
        public string fabricante { get; set; }

        public override string ToString()
        {
            return $"{base.titulo}: {minJugadores} y {maxJugadores} jugadores";
        }

    }
}
