using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat1
{
    public partial class Sedište : UserControl
    {
        public Sedište()
        {
            InitializeComponent();
            pictureBox1.Show(); pictureBox2.Hide();
           
        }

        public Sedište(bool kupljeno)
        {
            InitializeComponent();
            pictureBox1.Hide(); pictureBox2.Show();
            zauzeto = true;
            
        }


        bool zauzeto=false;
        public bool State { get { return zauzeto; }  }
        static int  max6 = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (max6 < 6)
            {
                pictureBox1.Hide(); pictureBox2.Show();
                max6++;zauzeto = true;
            }
            else MessageBox.Show("mozete izabrati maksimum 6 sedista");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Show(); pictureBox2.Hide();
            max6--;
            zauzeto = false;
        }
    }
}
