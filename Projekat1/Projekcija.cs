using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    [Serializable]
    public  class Projekcija
    {
        int ID;
        static int IDgen = 0;
        DateTime vreme;
         Film film;
        Sala sala;
        Karta karta;
        List<Karta> karte;

        public  Projekcija(DateTime _vreme, Film _film, Sala _sala,Karta _karta)
        {
            karta = _karta;
            int br_karti = _sala.getmesta();
            karte = new List<Karta>(br_karti);
            vreme = _vreme;
            film = _film;
            sala = _sala;
            ID = IDgen++;
            for (int i = 0; i < sala.getmesta(); i++)
            karte.Add(_karta);
            
        }
        public Film getfilm() { return film; }
        public  Sala getsala() { return sala; }
        public Karta getkarta() { return karta; }
        public List<Karta> getKarte() { return karte; }
        public  string getvreme() { return vreme.Day+"."+vreme.Month + "."+vreme.Year +
               "  "+vreme.TimeOfDay.Hours+":"+vreme.TimeOfDay.Minutes+":"+vreme.TimeOfDay.Seconds; }

        public override string ToString()
        {
            return sala + " " + getvreme();
        }
        public void setIDgen(int br) {  IDgen=br; }
        public int getID() { return ID; }
    }
}
