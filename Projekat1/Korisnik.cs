using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat1
{
    [Serializable]
    public class Korisnik
    {
        string username;
        string password;
        bool ocenio = false;
       public Korisnik(string user,string pass) {

            username = user;
            password=pass;
        }
        public string getname() { return username; }
        public string getpass() { return password; }
        public bool getfleg() { return ocenio; }
        public void setfleg() {  ocenio=true; }
    }
}
