using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
   public class Data
    {
         bool login = false;
         List<Korisnik> lista_korisnika = new List<Korisnik>();
         List<Film> lista_filmova = new List<Film>();
        List<Sala> lista_sala = new List<Sala>();
         List<Karta> lista_karti = new List<Karta>();
         List<Projekcija> lista_projekcija = new List<Projekcija>();

        public List<Projekcija> getlista_projekcija() { return lista_projekcija; }
        public List<Karta> getlista_karti() { return lista_karti; }
        public List<Film> getlista_filmova() { return lista_filmova; }
        public List<Sala> getlista_sala() { return lista_sala; }
        public List<Korisnik> getlista_korisnika() { return lista_korisnika; }
        public bool getlogin() { return login; }
        //Deserijalizacija
        public Object Deserijalizacija<T>(String putanja)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenRead(putanja);

            List<T> obj_list = new List<T>();
            obj_list = bf.Deserialize(fs) as List<T>;
            fs.Dispose();
            return obj_list;

        }

        //Serijalizacija
        public void Serijalizacija<T>(String putanja, List<T> obj_list)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.OpenWrite(putanja);
            bf.Serialize(fs, obj_list);
            fs.Dispose();
        }

    }
}
