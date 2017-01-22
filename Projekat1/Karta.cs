using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    [Serializable]
    public class Karta
    {
        int ID;
        static int IDgen = 0;
        int cena;
        Film film;
        Sala sala;
        double sediste;


        public  Karta(int _cena, Film _film, Sala _sala)
        {
            cena = _cena;
            film = _film;
            sala = _sala;
            ID = IDgen++;
        }
        public void setIDgen(int br) { IDgen = br; }
        public int getID() { return ID; }
        public Film getfilm() { return film; }
        public Sala getsala() { return sala; }
        public int getCena() { return cena; }
        public void setsediste(double br) { sediste=br; }
        public override string ToString()
        {
            return cena.ToString();
        }
    }
}
