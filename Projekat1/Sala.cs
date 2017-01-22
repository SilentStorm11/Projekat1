using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    [Serializable]
    public class Sala
    {
        int ID;
        
        string naziv;
        int br_mesta;
        static int IDgen=0;
        Karta[,] sedista;
      
         
        public Sala(string n, int _br)
        {
            ID = IDgen++;
            naziv = n;
            br_mesta=_br;
            int M = br_mesta / 10;
            int N = br_mesta % 10;
            if (N != 0) M++;
            sedista = new Karta[10,10];

        }
        public Karta[,] getSedista() { return sedista; }
        public string getnaziv() { return naziv; }
        public int getmesta() { return br_mesta; }
        public void setIDgen(int br) { IDgen = br; }
        public int getID() { return ID; }
        public override string ToString() { return naziv; }
    }

    

}
