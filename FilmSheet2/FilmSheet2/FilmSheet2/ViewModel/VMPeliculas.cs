using FilmSheet.Models;
using System;
using FilmSheet2;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FilmSheet.ViewModel
{
    class VMPeliculas
    {
        public VMPeliculas() {
            Peliculas peli1 = new Peliculas() {
                titulo = "Avengers Endgame",
                author = "Hermanos Russo",
                fechaPublicacion = new DateTime(2019, 4, 24),
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_.jpg",
            };
            Peliculas peli2 = new Peliculas()
            {
                titulo = "Gato con botas: El ultimo deseo",
                author = "Chris Miller",
                fechaPublicacion = new DateTime(2022, 12, 21),
                ImageUrl = "https://cdn.colombia.com/sdi/2022/12/21/la-pelicula-el-gato-con-botas-el-ultimo-deseo-es-el-retorno-a-la-saga-shrek-una-decada-despues-1100249.jpg",
            };

            Peliculas peli3 = new Peliculas()
            {
                titulo = "Antman y la avistpa: Quantumania",
                author = "Chris Miller",
                fechaPublicacion = new DateTime(2022, 12, 21),
                ImageUrl = "https://images.theconversation.com/files/510659/original/file-20230216-28-6fha3j.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1200&h=1200.0&fit=crop",
            };

            Peliculas peli4 = new Peliculas()
            {
                titulo = "Shazam: Fury of the gods",
                author = "Peyton Reed",
                fechaPublicacion = new DateTime(2022, 12, 21),
                ImageUrl = "https://static.wikia.nocookie.net/dcextendeduniverse/images/8/82/Shazam_-_Official_New_Poster.png/revision/latest?cb=20210518032729&path-prefix=es",
            };

            Peliculas peli5 = new Peliculas()
            {
                titulo = "Capitan America: Civil War",
                author = "Hermanos Russo",
                fechaPublicacion = new DateTime(2022, 12, 21),
                ImageUrl = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/669963075E813343A697051B67F8BFD61C1F54846BC1B22D6AB07832CEF2FEDF/scale?width=1200&aspectRatio=1.78&format=jpeg",
            };

            ListaPeli.Add(peli1);
            ListaPeli.Add(peli2);
            ListaPeli.Add(peli3);
            ListaPeli.Add(peli4);
            ListaPeli.Add(peli5);


            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "peliculas.peli");

            Stream archivo = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(archivo, ListaPeli);
            archivo.Close();

            App.Current.Properties["ListaPeliculas"] = ListaPeli;

        }

        ObservableCollection<Peliculas> listaPeli = new ObservableCollection<Peliculas>();
        public ObservableCollection<Peliculas> ListaPeli
        {
            get => listaPeli;
            set
            {
                listaPeli = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaPeli));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
