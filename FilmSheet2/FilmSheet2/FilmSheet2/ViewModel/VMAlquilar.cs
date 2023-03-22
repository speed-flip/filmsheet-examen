using FilmSheet.Models;
using System;
using FilmSheet2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xamarin.Forms;

namespace FilmSheet.ViewModel
{
    public class VMAlquilar : INotifyPropertyChanged
    {
        public bool showInfo { get; set; } = false;
        public VMAlquilar() {
            AbrirListaJM();
            this.showInfo = false;

            try {
                listaLibros = App.Current.Properties["ListaLibros"] as ObservableCollection<Libro>;
                listaPeliculas = App.Current.Properties["ListaPeliculas"] as ObservableCollection<Peliculas>;
                listaJM = App.Current.Properties["ListaJM"] as ObservableCollection<JuegosMesa>;
                App.Current.Properties["Persona"] = usuario;
            }
            catch { }

            Alquilar = new Command(() => {
                this.showInfo = true;
                usuario.libroH = libroSeleccionado;
                Debug.WriteLine(usuario.libroH);
                App.Current.Properties["libroSeleccionado"] = libroSeleccionado;
                App.Current.Properties["PeliSeleccionada"] = peliculaSeleccionada;
                App.Current.Properties["JuegoSeleccionado"] = juegoSeleccionado;
            });

        }

        private void AbrirListaJM()
        {
            try
            {
                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "juegos.jm4");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                listaJM = (ObservableCollection<JuegosMesa>)formatter.Deserialize(archivo);
                archivo.Close();

                App.Current.Properties["ListaJM"] = listaJM;

            }
            catch (Exception ex)
            {
                listaJM = new ObservableCollection<JuegosMesa>();
            }
        }

        Libro libroSeleccionado = new Libro();
        public Libro LibroSeleccionado{
            get => libroSeleccionado;
            set {
                libroSeleccionado = value;
                var arg = new PropertyChangedEventArgs(nameof(LibroSeleccionado));
                PropertyChanged?.Invoke(this, arg);
            }

        }

        Peliculas peliculaSeleccionada = new Peliculas();
        public Peliculas PeliculaSeleccionada {
            get => peliculaSeleccionada;
            set {
                peliculaSeleccionada = value;
                var arg = new PropertyChangedEventArgs(nameof(PeliculaSeleccionada));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        JuegosMesa juegoSeleccionado = new JuegosMesa();
        public JuegosMesa JuegoSeleccionado {
            get => juegoSeleccionado;
            set {
                juegoSeleccionado = value;
                var arg = new PropertyChangedEventArgs(nameof(JuegoSeleccionado));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        Persona usuario = new Persona();
        public ObservableCollection<Libro> listaLibros { get; set; } = new ObservableCollection<Libro>();
        public ObservableCollection<Peliculas> listaPeliculas { get; set; } = new ObservableCollection<Peliculas>();
        public ObservableCollection<JuegosMesa> listaJM { get; set; } = new ObservableCollection<JuegosMesa>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Command Alquilar { get; }
    }
}
