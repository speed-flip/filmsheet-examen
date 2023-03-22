using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FilmSheet.Models
{
    [Serializable]
    public class Persona
    {
        public string nombre { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public ObservableCollection<Libro> listaLibros { get; set; } = new ObservableCollection<Libro>();
        public List<ObservableCollection<Peliculas>> listaPeliculas { get; set; } = new List<ObservableCollection<Peliculas>>();
        public List<ObservableCollection<JuegosMesa>> listaJM { get; set; } = new List<ObservableCollection<JuegosMesa>>();
        public Libro libroH { get; set; } = new Libro();
        public Peliculas peliculaH { get; set; } = new Peliculas();
        public JuegosMesa JMH { get; set; } = new JuegosMesa();


        public override string ToString()
        {
            return $"Nombre: {nombre} email: {email} Nombre de usuario: {usuario}";
        }
    }
}
