using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat1
{
    public partial class Form1  : Form
    {
        public int id_korisnika;
        public bool login = false;
        public Data dat;
        


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox7.ImageLocation = "cineplex_logo.jpg";
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pregled_filma pregled = new pregled_filma(nova_forma);
            List<PictureBox> top6 = new List<PictureBox>(6);
            top6.Add(pictureBox1);
            top6.Add(pictureBox2);
            top6.Add(pictureBox3);
            top6.Add(pictureBox4);
            top6.Add(pictureBox5);
            top6.Add(pictureBox6);
            for (int i = 0; i < top6.Count; i++)
            {
                if (i < dat.getlista_filmova().Count)
                {
                    top6.ElementAt(i).Image = dat.getlista_filmova()[i].getslika();
                    top6.ElementAt(i).SizeMode= PictureBoxSizeMode.StretchImage;
                    top6.ElementAt(i).Click += new EventHandler(pregled);
                }
            }

        }


        public Form1()
        {
            

            dat = new Data();
            InitializeComponent();
            if (File.Exists("registrovani_korisnici.bin"))
            { dat.getlista_korisnika().AddRange(dat.Deserijalizacija<Korisnik>("registrovani_korisnici.bin") as List<Korisnik>); }
            if (File.Exists("filmovi.bin"))
            {
                dat.getlista_filmova().AddRange(dat.Deserijalizacija<Film>("filmovi.bin") as List<Film>);

                if (dat.getlista_filmova().Count > 0) for (int i = 0; i < dat.getlista_filmova().Count; i++)
                    {
                        dat.getlista_filmova()[i].setIDgen(dat.getlista_filmova()[dat.getlista_filmova().Count - 1].getID());
                    }
            }
            if (File.Exists("sale.bin"))
            {
                dat.getlista_sala().AddRange(dat.Deserijalizacija<Sala>("sale.bin") as List<Sala>);
                if (dat.getlista_sala().Count > 0) for (int i = 0; i < dat.getlista_sala().Count; i++)
                    {
                        dat.getlista_sala()[i].setIDgen(dat.getlista_sala()[dat.getlista_sala().Count - 1].getID());
                    }
            }
            if (File.Exists("projekcije.bin"))
            {
                dat.getlista_projekcija().AddRange(dat.Deserijalizacija<Projekcija>("projekcije.bin") as List<Projekcija>);
                if (dat.getlista_projekcija().Count > 0) for (int i = 0; i < dat.getlista_projekcija().Count; i++)
                    {
                        dat.getlista_projekcija()[i].setIDgen(dat.getlista_projekcija()[dat.getlista_projekcija().Count - 1].getID());
                    }
            }

            if (File.Exists("karte.bin"))
            {
                dat.getlista_karti().AddRange(dat.Deserijalizacija<Karta>("karte.bin") as List<Karta>);
                if (dat.getlista_karti().Count > 0) for (int i = 0; i < dat.getlista_karti().Count; i++)
                    {
                        dat.getlista_karti()[i].setIDgen(dat.getlista_karti()[dat.getlista_karti().Count - 1].getID());
                    }
            }
            

                    for (int x = 0; x < dat.getlista_filmova().Count; x++)
                    {
                        comboBox1.Items.Add(dat.getlista_filmova()[x]);
                
            }
        }
        public delegate void pregled_filma(object sender, EventArgs e);
        public void nova_forma(object sender, EventArgs e)
        {
            Film_Forma f = new Film_Forma(this, (sender as PictureBox).Image);
            f.Show();

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registracija_Form f = new Registracija_Form(this); f.ShowDialog();
        }

         
        


        private void Sign_in_btn(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            { Form_admin f = new Form_admin(this);
                f.Show();}


            for (int i = 0; i < dat.getlista_korisnika().Count; i++)
                if (textBox1.Text.Trim() == dat.getlista_korisnika().ElementAt(i).getname() && textBox2.Text.Trim() == dat.getlista_korisnika().ElementAt(i).getpass())
                {
                    login = true;
                    id_korisnika = i;
                    groupBox1.Show();
                    groupBox2.Hide();
                    label4.Text = "Dobrodošli  " + dat.getlista_korisnika().ElementAt(i).getname();
                    break;
                }
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                MessageBox.Show("Niste uneli jedan od parametara");

            else if (!login && textBox1.Text.Trim() != "admin" && textBox2.Text.Trim() != "admin")
            {
                DialogResult odg = MessageBox.Show("Korisnik pod imenom " + textBox1.Text + " ne postoji, kreirajte ga?",
                  "Greska u username-u", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (odg == DialogResult.Yes)
                { Registracija_Form f = new Registracija_Form(this); f.ShowDialog(); }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                Form_Korisnik f = new Form_Korisnik(this, comboBox2.SelectedItem as Projekcija);
                f.Show();
            }
            else MessageBox.Show("morate odabrati film i projekciju");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear(); 
            for (int i = 0; i < dat.getlista_projekcija().Count; i++)
            {
                if (dat.getlista_projekcija()[i].getfilm().ToString() == comboBox1.SelectedItem.ToString())
                    comboBox2.Items.Add(dat.getlista_projekcija()[i]);
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < dat.getlista_filmova().Count; i++)
            {
             comboBox1.Items.Add(dat.getlista_filmova()[i]);
            }
        }


        
    }
}
