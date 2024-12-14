using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucantop_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int yerX=5, yerY=5,can=3;
        private void carpmaOlayi()
        {
            //YUKARI carpma olayı
            if(ball.Top<=label3.Bottom)
            {
                yerY = yerY * -1;
            }
            //kontrol çubuguna  çarpma 
            if(ball.Bottom >=kontrol.Top &&ball.Left>=kontrol.Left &&ball.Right <=kontrol.Right)
            {
                yerY=yerY * -1;
            }
            //sağa çarpma olayı
           else if (ball.Right >= label2.Left)
            {
                yerX=yerX * -1;
            }
            //sola çarpma olayı
         else   if (ball.Left <= label1.Right)
            {
                yerX=yerX * -1;
            }
        }
        private void yanmaOlayi(object sender,EventArgs e)
        {
            if (ball.Top >= label2.Bottom)
            {
                if (can > 0)
                {
                    timer1.Stop();
                    can--;
                    MessageBox.Show("KAYBETTİNİZ!KALAN CAN:"+can.ToString(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1_Load(sender, e);
                }
                if (can == 0)
                {
                    MessageBox.Show("OYUN BİTTİ!");
                    timer1.Stop();
                }
            }
            label4.Text=can.ToString();
        }
        private void TopBsa()
        {
            ball.Location=new Point(439,187);

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            TopBsa();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Location=new Point(ball.Location.X+yerX, ball.Location.Y+yerY);
            carpmaOlayi();
            yanmaOlayi(sender, e);

        }
    }
}
