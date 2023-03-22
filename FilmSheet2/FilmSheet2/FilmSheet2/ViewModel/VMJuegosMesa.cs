using FilmSheet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FilmSheet2;

namespace FilmSheet.ViewModel
{
    class VMJuegosMesa
    {
        public VMJuegosMesa() {
            CrearJuegoMesa = new Command(() => {
                JuegosMesa jm = new JuegosMesa() {
                    titulo = this.titulo,
                    edad = this.edad,
                    fabricante = this.fabricante,
                    ImageUrl = this.imagen,
                    maxJugadores = this.maxJugadores,
                    minJugadores = this.minJugadores,
                };

                ListaJM.Add(jm);
                this.titulo = "";
                this.edad = 0;
                this.fabricante = "";
                this.imagen = "";
                this.maxJugadores = 0;
                this.minJugadores = 0;

                //Serializacion
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "juegos.jm4");

                Stream archivo = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, ListaJM);
                archivo.Close();

                /*Fin de Rutina de Serializacion*/

                App.Current.Properties["ListaJM"] = ListaJM;

            });

        }

        string titulo;
        public string Titulo {
            get => titulo;
            set {
                titulo = value;
                var arg = new PropertyChangedEventArgs(nameof(Titulo));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        int edad;
        public int Edad {
            get => edad;
            set {
                edad = value;
                var arg = new PropertyChangedEventArgs(nameof(Edad));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        int minJugadores;
        public int MinJugadores
        {
            get => minJugadores;
            set
            {
                minJugadores = value;
                var arg = new PropertyChangedEventArgs(nameof(MinJugadores));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        int maxJugadores;
        public int MaxJugadores
        {
            get => maxJugadores;
            set
            {
                maxJugadores = value;
                var arg = new PropertyChangedEventArgs(nameof(MaxJugadores));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string fabricante;
        public string Fabricante
        {
            get => fabricante;
            set
            {
                fabricante = value;
                var arg = new PropertyChangedEventArgs(nameof(Fabricante));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string imagen;
        public string Imagen {
            get => imagen;
            set {
                imagen = value;
                var arg = new PropertyChangedEventArgs(nameof(Imagen));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        ObservableCollection<JuegosMesa> listaJM = new ObservableCollection<JuegosMesa>();
        public ObservableCollection<JuegosMesa> ListaJM {
            get => listaJM;
            set {
                listaJM = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaJM));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command CrearJuegoMesa { get; }

    }
}
