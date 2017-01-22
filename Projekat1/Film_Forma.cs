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
    public partial class Film_Forma : Form
    {
        Form1 f1;
        Film film;
        public Film_Forma(Form1 osnovna_forma, Image _slika)
        {
            f1 = osnovna_forma;
            Image slika = _slika;
            InitializeComponent();
            if (!f1.login)
            { panel3.Hide(); button2.Hide(); }
            for (int i = 0; i < f1.dat.getlista_filmova().Count; i++)
            {
                if (f1.dat.getlista_filmova()[i].getslika() == slika)
                    film = f1.dat.getlista_filmova()[i];

            }


            label1.Text = film.getnaziv();
            label2.Text = film.getzanr();
            textBox1.Text = film.getopis();
            pictureBox1.Image = film.getslika();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
            
            

        private void button2_Click(object sender, EventArgs e)
        {
            getRB(radioButton1);
            getRB(radioButton2);
            getRB(radioButton3);
            getRB(radioButton4);
            getRB(radioButton5);
        }
        private void getRB(RadioButton RB)
        {
            if (RB.Checked && !f1.dat.getlista_korisnika().ElementAt(f1.id_korisnika).getfleg())
            {
                f1.dat.getlista_korisnika().ElementAt(f1.id_korisnika).setfleg();

                film.setocene(int.Parse(RB.Text));
                f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());
                panel3.Hide();
                button2.Hide();

            }
        }
    }
}
