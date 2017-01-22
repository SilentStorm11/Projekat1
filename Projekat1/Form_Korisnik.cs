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
    public partial class Form_Korisnik : Form
    {
        Rectangle r;
        Sedište[,] matrica;
        Form1 f1;
        int sirina; 
         int visina;
        Projekcija projekcija;
        Film film;
        Sala sala;
        Karta karta;
        int br;
        int redovi;
        Karta[,] sedista;
        int zauzeta_mesta=0;
        int slobodna_mesta=0;
   
        void postavi_sedista(Sedište[,] matrica)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < redovi; j++)
                {
                    matrica[i, j].Height = visina;
                    matrica[i, j].Width = sirina;
                    matrica[i, j].Top = matrica[i, j].Height * j;
                    matrica[i, j].Left = matrica[i, j].Width * i;
                }
            for (int i = 0; i < br%10; i++)
                for (int j = redovi; j < redovi+1; j++)
                {
                    matrica[i, j].Height = visina;
                    matrica[i, j].Width = sirina;
                    matrica[i, j].Top = matrica[i, j].Height * j;
                    matrica[i, j].Left = matrica[i, j].Width * i;
                }
        }
      private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }
        

        public Form_Korisnik(Form1 originalna_forma,Projekcija p)
        {
            Invalidate();
            
            f1 = originalna_forma;
            projekcija = p;
            film = projekcija.getfilm();
            sala = projekcija.getsala();
            karta = projekcija.getkarta();

            InitializeComponent();
            
            sirina = panel2.Width/10;
            visina = panel2.Height/10;
            matrica = new Sedište[10, 10];

            label1.Text = film.getnaziv();
            label2.Text = film.getzanr();
            label3.Text = karta.getCena().ToString()+" DIN";

            label4.Text = (film.getsuma() / film.getocene().Count).ToString() + " od " + film.getocene().Count.ToString();
            if (film.getocene().Count == 0) label4.Hide();
            textBox1.Text= film.getopis();
            br=sala.getmesta();
            sedista=sala.getSedista();
            pictureBox1.Image = film.getslika();
            
            for (int i = 0; i<film.getocene().Count; i++)
            {
                film.setsuma(film.getocene()[i]);
            }
            
            redovi = br / 10;
            if (!f1.login)
            {
                panel2.Hide(); button1.Hide(); panel3.Hide(); linkLabel1.Show();
                button2.Hide();panel4.Hide();label5.Hide(); label3.Hide(); label4.Hide();
            }
            else
            { linkLabel1.Hide(); 
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < redovi; j++){
                        if (sedista[i, j] != null)
                        {
                            
                            matrica[i, j] = new Sedište(true);
                            panel2.Controls.Add(matrica[i, j]);
                            matrica[i, j].Enabled = false;
                            zauzeta_mesta++;
                        }
                        else
                        {
                            matrica[i, j] = new Sedište();
                            panel2.Controls.Add(matrica[i, j]);
                            slobodna_mesta++;
                        }
                    }
                for (int i = 0; i < br % 10; i++)
                    for (int j = redovi; j < redovi+1; j++)
                    {
                        if (sedista[i, j] != null)
                        {
                            
                            matrica[i, j] = new Sedište(true);
                            panel2.Controls.Add(matrica[i, j]);
                            matrica[i,j].Enabled = false;
                            zauzeta_mesta++;
                        }
                        else
                        {
                            matrica[i, j] = new Sedište();
                            panel2.Controls.Add(matrica[i, j]);
                            slobodna_mesta++;
                        }
                    }


                postavi_sedista(matrica);
                
            }
    }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registracija_Form rf = new Registracija_Form(f1);
            rf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            getRB(radioButton1);
            getRB(radioButton2);
            getRB(radioButton3);
            getRB(radioButton4);
            getRB(radioButton5);
        }

            private void getRB(RadioButton RB) {
            if (RB.Checked && !f1.dat.getlista_korisnika().ElementAt(f1.id_korisnika).getfleg())
            {
                f1.dat.getlista_korisnika().ElementAt(f1.id_korisnika).setfleg();

                film.setocene(int.Parse(RB.Text));
                label4.Text = (film.getsuma() / film.getocene().Count).ToString() + " od " + film.getocene().Count.ToString();
                f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());
                
            }
            else { panel3.Hide(); }
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < redovi; j++)
                {
                    if (matrica[i, j].State)
                    {
                        
                        sedista[i, j] = karta;
                        projekcija.getKarte().RemoveAt(1);
                        karta.setsediste((i * 10 + j) / 10);
                    }
                }
            for (int i = 0; i < br % 10; i++)
                for (int j = redovi; j < redovi + 1; j++)
                {
                    if (matrica[i, j].State)
                    {
                        sedista[i, j] = karta; projekcija.getKarte().RemoveAt(1);
                        karta.setsediste((i * 10 + j) / 10);
                    }
                }
            f1.dat.Serijalizacija<Karta>("karte.bin", f1.dat.getlista_karti());
            f1.dat.Serijalizacija<Sala>("sale.bin", f1.dat.getlista_sala());
            f1.dat.Serijalizacija<Projekcija>("projekcije.bin", f1.dat.getlista_projekcija());
            f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());
            MessageBox.Show("uspesno ste kupili kartu");
        }

        private void Form_Korisnik_Load(object sender, EventArgs e)
        {

        }

        private void Form_Korisnik_Paint(object sender, PaintEventArgs e)
        {
            if (f1.login)
            {
                Graphics fg = CreateGraphics();
                // Graphics dc = e.Graphics;
                //Pen bluePen = new Pen(Color.Blue, 10);
                // Pen redPen = new Pen(Color.Red, 10);
                SolidBrush red = new SolidBrush(Color.Red);
                SolidBrush blue = new SolidBrush(Color.Blue);
                RectangleF r1 = new RectangleF(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height);
                RectangleF r2 = new RectangleF(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height * zauzeta_mesta / slobodna_mesta);
                //dc.DrawRectangle(bluePen, r1);
                //dc.DrawRectangle(redPen, r2);

                fg.FillRectangle(blue, r1);
                fg.FillRectangle(red, r2);
                panel1.Hide();
                label5.Text = "zauzeto je " + (zauzeta_mesta * 1.0 / slobodna_mesta * 100.0).ToString() + "% sale";
            }
        }
    }  
    }

