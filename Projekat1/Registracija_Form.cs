using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat1
{
    public partial class Registracija_Form : Form
    {
        public Form1 f1;
        public Registracija_Form(Form1 Form1)
        {
            f1 = Form1;
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            { MessageBox.Show("Morate uneti podatke"); ok = false; }

            else if (textBox2.Text.Trim() != textBox3.Text.Trim())

            { MessageBox.Show("Šifre vam se ne poklapaju"); ok = false; }

            else
            {
                for (int i = 0; i < f1.dat.getlista_korisnika().Count; i++)
                    if (f1.dat.getlista_korisnika().ElementAt(i).getname() == textBox1.Text.Trim())
                    {
                        MessageBox.Show("Korisnik sa takvim imenom vec postoji"); ok = false; break;
                    }
            }
            
            if(ok){
                Korisnik k = new Korisnik(textBox1.Text.Trim(), textBox2.Text.Trim());
                f1.dat.getlista_korisnika().Add(k);
                f1.dat.Serijalizacija<Korisnik>("registrovani_korisnici.bin", f1.dat.getlista_korisnika());
                f1.dat.getlista_korisnika().AddRange(f1.dat.Deserijalizacija<Korisnik>("registrovani_korisnici.bin") as List<Korisnik>);
                MessageBox.Show("Uspesno ste se registrovali " + k.getname());
                this.Hide();
            }
            
          }
        }
    }

