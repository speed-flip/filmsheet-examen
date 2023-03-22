using FilmSheet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using FilmSheet2;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Diagnostics;

namespace FilmSheet.ViewModel
{
    public class VMPerfil
    {
        public VMPerfil() {
            AbrirPersona();

            try
            {
                App.Current.Properties["Persona"] = Person;
                libro = App.Current.Properties["libroSeleccionado"] as Libro;
                Debug.WriteLine(libro);
            }
            catch { }



        }

        private void AbrirPersona()
        {
            try
            {
                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "persona2.per");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                persona = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                App.Current.Properties["Persona"] = persona;

            }
            catch (Exception ex)
            {
                persona = new Persona();
            }
        }

        Persona persona;
        public Persona Person
        {
            get => persona;
            set
            {
                persona = value;
                var arg = new PropertyChangedEventArgs(nameof(Persona));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Libro libro = new Libro();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
