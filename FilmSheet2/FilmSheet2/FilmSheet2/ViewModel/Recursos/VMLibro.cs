using FilmSheet.Models;
using FilmSheet2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace FilmSheet.ViewModel.Recursos
{
    public class VMLibro: INotifyPropertyChanged
    {
        public VMLibro() {
            try
            {
                
                App.Current.Properties["Persona"] = persona;
            }
            catch { }

            Libro lb1 = new Libro() {
                titulo = "Loca Academia de Piratas",
                author = "Leonardo Dicaprio",
                fechaPublicacion = new DateTime(2003, 4, 27),
                ImageUrl = "https://www.aphernandez.com/uploads/2/5/5/8/25584691/loca-academia-pirata-portada-letra-ok_4.jpg",
            };
            Libro lb2 = new Libro()
            {
                titulo = "100 años de soledad",
                author = "Gabriel Garcia Marquez",
                fechaPublicacion = new DateTime(2003, 4, 27),
                ImageUrl = "https://m.media-amazon.com/images/I/71YoFJSz3LL.jpg",
            };

            Libro lb3 = new Libro()
            {
                titulo = "El señor de los anillos",
                author = "J.R.R. Tolkien",
                fechaPublicacion = new DateTime(2003, 4, 27),
                ImageUrl = "https://www.gonvill.com.mx/imagenes/9788445/978844500068.JPG",
            };

            Libro lb4 = new Libro()
            {
                titulo = "Don Quijote de la mancha",
                author = "Miguel de Cervantes",
                fechaPublicacion = new DateTime(2003, 4, 27),
                ImageUrl = "https://www.rbalibros.com/medio/2019/03/05/don-quijote-de-la-mancha_960d6e26_500x748.jpg",
            };

            ListaLibros.Add(lb1);
            ListaLibros.Add(lb2);
            ListaLibros.Add(lb3);
            ListaLibros.Add(lb4);

            //Serializacion de libros
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.lb7");

            Stream archivo = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(archivo, ListaLibros);
            archivo.Close();

            /*Fin de Rutina de Serializacion*/

            App.Current.Properties["ListaLibros"] = ListaLibros;
        }

        private void AbrirListaLibros() {
            try {
                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "libros.lb7");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaLibros = (ObservableCollection<Libro>)formatter.Deserialize(archivo);
                archivo.Close();

                App.Current.Properties["ListaLibros"] = ListaLibros;

            }
            catch (Exception ex)
            {
                ListaLibros = new ObservableCollection<Libro>();
            }
        }

        ObservableCollection<Libro> listaLibros = new ObservableCollection<Libro>();
        public ObservableCollection<Libro> ListaLibros{
            get => listaLibros;
            set{
                listaLibros = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaLibros));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Persona persona { get; set; } = new Persona();

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
