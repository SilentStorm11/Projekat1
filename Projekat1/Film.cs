using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    [Serializable]
    public class Film
    {
        int ID;
        static int IDgen = 0;
        string naziv;
        string zanr;
        string opis;
        Image slika;
        List<int> ocene;
        double suma;
       


      public  Film(string _naziv,string _zanr,string _opis,Image _slika) {
            naziv = _naziv;
            zanr = _zanr;
            opis = _opis;
            ID = IDgen++;
            ocene = new List<int>();
            slika = _slika; 

        }

       public override string  ToString() { return naziv; }

      public  string getnaziv() { return naziv; }
        public string getzanr() { return zanr; }
        public string getopis() { return opis; }
        public void setocene(int br) { ocene.Add(br); }
        public List<int> getocene() {return  ocene; }
        public void setIDgen(int br) { IDgen = br; }
        public int getID() { return ID; }
        public Image getslika() { return slika; }
        public double getsuma() { return suma; }
        public void setsuma(double i) { suma = i; ; }
        // public void setnaziv(string s) {  naziv=s; }
        // public void setzanr(string s) {  zanr = s; }
        // public void setopis(string s) {  opis = s; }






    }
}
