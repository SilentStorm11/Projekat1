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
    public partial class Form_admin : Form
    {
        Form1 f1;
        

        public Form_admin(Form1 osnovna_forma)
        {
            InitializeComponent();
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            f1 = osnovna_forma;


            for (int i = 0; i < f1.dat.getlista_filmova().Count; i++) {
                comboBox1.Items.Add(f1.dat.getlista_filmova()[i]);
            }
            for (int i = 0; i < f1.dat.getlista_sala().Count; i++)
            {
                comboBox2.Items.Add(f1.dat.getlista_sala()[i]);
            }
            for (int i = 0; i < f1.dat.getlista_filmova().Count; i++)
            {
                comboBox3.Items.Add(f1.dat.getlista_filmova()[i]);
            }
            for (int i = 0; i < f1.dat.getlista_sala().Count; i++)
            {
                comboBox4.Items.Add(f1.dat.getlista_sala()[i]);
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != ""&&pictureBox1.Image!=null)
            {
                
                Film f = new Film(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), pictureBox1.Image);
                f1.dat.getlista_filmova().Add(f);
                f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());

                    comboBox1.Items.Add(f);
                comboBox3.Items.Add(f);


                MessageBox.Show("Film je uspešno dodat");
            }
            else MessageBox.Show("Unesite sve podatke");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && int.Parse(textBox6.Text.Trim())<101)
            {
                Sala s = new Sala(textBox5.Text.Trim(), int.Parse(textBox6.Text.Trim()));
                f1.dat.getlista_sala().Add(s);
                f1.dat.Serijalizacija<Sala>("sale.bin", f1.dat.getlista_sala());
       
                comboBox2.Items.Add(s);
                comboBox4.Items.Add(s);
                MessageBox.Show("Sala je uspešno dodata");
            }
            else MessageBox.Show("Unesite sve podatke");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!=null&& comboBox2.SelectedItem != null&&comboBox5.SelectedItem != null)
            {
                DateTime date = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;

                Projekcija p = new Projekcija(date, comboBox1.SelectedItem as Film, comboBox2.SelectedItem as Sala, comboBox5.SelectedItem as Karta);
                f1.dat.getlista_projekcija().Add(p);
                f1.dat.Serijalizacija<Projekcija>("projekcije.bin", f1.dat.getlista_projekcija());
                
            
                MessageBox.Show("Projekcija je uspešno dodata");
            }
            else MessageBox.Show("Unesite sve podatke");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && textBox4.Text.Trim() != "")
            {
                

                Karta k = new Karta(int.Parse(textBox4.Text), comboBox3.SelectedItem as Film, comboBox4.SelectedItem as Sala);
                f1.dat.getlista_karti().Add(k);
                f1.dat.Serijalizacija<Karta>("karte.bin", f1.dat.getlista_karti());
                
                MessageBox.Show("Karta je uspešno dodata");
            }
            else MessageBox.Show("Unesite sve podatke");


        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                f1.dat.getlista_filmova().RemoveAt(int.Parse(textBox8.Text));
                f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                pictureBox1.Image = f1.dat.getlista_filmova().ElementAt(int.Parse(textBox9.Text)).getslika();
                textBox1.Text = f1.dat.getlista_filmova().ElementAt(int.Parse(textBox9.Text)).getnaziv();
                textBox2.Text = f1.dat.getlista_filmova().ElementAt(int.Parse(textBox9.Text)).getzanr();
                textBox3.Text = f1.dat.getlista_filmova().ElementAt(int.Parse(textBox9.Text)).getopis();
                f1.dat.getlista_filmova().RemoveAt(int.Parse(textBox9.Text));
                f1.dat.Serijalizacija<Film>("filmovi.bin", f1.dat.getlista_filmova());
               

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
            {
                f1.dat.getlista_sala().RemoveAt(int.Parse(textBox11.Text));
                f1.dat.Serijalizacija<Sala>("sale.bin", f1.dat.getlista_sala());
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != "")
            {
                textBox5.Text = f1.dat.getlista_sala().ElementAt(int.Parse(textBox10.Text)).getnaziv();
                textBox6.Text = f1.dat.getlista_sala().ElementAt(int.Parse(textBox10.Text)).getmesta().ToString();
                f1.dat.getlista_sala().RemoveAt(int.Parse(textBox10.Text));
                f1.dat.Serijalizacija<Sala>("sale.bin", f1.dat.getlista_sala());
               
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           if(textBox13.Text!="") f1.dat.getlista_projekcija().RemoveAt(int.Parse(textBox13.Text));
            f1.dat.Serijalizacija<Projekcija>("projekcije.bin", f1.dat.getlista_projekcija());
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "") {
                comboBox2.SelectedText = f1.dat.getlista_projekcija().ElementAt(int.Parse(textBox12.Text)).getsala().ToString();
                comboBox1.SelectedText = f1.dat.getlista_projekcija().ElementAt(int.Parse(textBox12.Text)).getfilm().ToString();
            comboBox5.SelectedText = f1.dat.getlista_projekcija().ElementAt(int.Parse(textBox12.Text)).getkarta().ToString();

                f1.dat.getlista_projekcija().RemoveAt(int.Parse(textBox12.Text));
            f1.dat.Serijalizacija<Projekcija>("projekcije.bin", f1.dat.getlista_projekcija());
        }
            

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "")
            {
                f1.dat.getlista_karti().RemoveAt(int.Parse(textBox15.Text));
                f1.dat.Serijalizacija<Karta>("karte.bin", f1.dat.getlista_karti());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox14.Text != "")
            {
                comboBox3.SelectedText = f1.dat.getlista_karti().ElementAt(int.Parse(textBox14.Text)).getfilm().ToString();
                comboBox4.SelectedText = f1.dat.getlista_karti().ElementAt(int.Parse(textBox14.Text)).getsala().ToString();
                textBox4.Text = f1.dat.getlista_karti().ElementAt(int.Parse(textBox14.Text)).getCena().ToString();
                f1.dat.getlista_karti().RemoveAt(int.Parse(textBox12.Text));
                f1.dat.Serijalizacija<Karta>("karte.bin", f1.dat.getlista_karti());
            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            for (int i = 0; i < f1.dat.getlista_karti().Count; i++)
            {
                if (comboBox2.SelectedItem!= null &&
                    comboBox1.SelectedItem!= null &&
                    f1.dat.getlista_karti()[i].getsala().ToString() == comboBox2.SelectedItem.ToString() &&
                    f1.dat.getlista_karti()[i].getfilm().ToString() == comboBox1.SelectedItem.ToString())
                    comboBox5.Items.Add(f1.dat.getlista_karti()[i]);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (filedialog.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = filedialog.FileName;
        }
    }
}
