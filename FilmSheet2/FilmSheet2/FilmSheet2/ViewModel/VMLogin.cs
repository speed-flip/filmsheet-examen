using FilmSheet.Models;
using FilmSheet.Views.Recursos;
using System;
using FilmSheet2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace FilmSheet.ViewModel
{
    class VMLogin: INotifyPropertyChanged
    {
        public VMLogin() {

            CrearCuenta = new Command(async () => {
                Persona p = new Persona() {
                    nombre = this.nombre,
                    email = this.email,
                    usuario = this.usuario,
                    password = this.password,
                };

                await Application.Current.MainPage.Navigation.PushAsync(new VMenu());

                //Serializacion de libros
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "persona2.per");

                Stream archivo = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();
                /*Fin de Rutina de Serializacion*/
                App.Current.Properties["Persona"] = p;  

            });
        }


        string nombre;
        public string Nombre {
            get => nombre;
            set {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string email;
        public string Email {
            get => email;
            set {
                email = value;
                var arg = new PropertyChangedEventArgs(nameof(Email));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string usuario;
        public string Usuario {
            get => usuario;
            set {
                usuario = value;
                var arg = new PropertyChangedEventArgs(nameof(Usuario));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                var arg = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command CrearCuenta { get; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
