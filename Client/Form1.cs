using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ServiceReference1;
using Contract;


namespace Client
{
    public partial class Form1 : Form
    {

        CanvasClient client1 = new CanvasClient("WSHttpBinding_ICanvas");
        CanvasClient client2 = new CanvasClient("WSHttpBinding_ICanvas2");
        CanvasClient client3 = new CanvasClient("WSHttpBinding_ICanvas3");
        CanvasClient client4 = new CanvasClient("NetTcpBinding_ICanvas");

        //CanvasClient client = client1;

        CanvasClient client;

        public Form1()
        {
            client = client1;
            InitializeComponent();
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            

            MyPoint mp = new MyPoint(e.Location.X, e.Location.Y);
            client.add(mp);

            Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MyPoint mp;
            for (int i = 0; i < client.size(); i++)
            {
                mp = client.get(i);
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(mp.X, mp.Y, 20, 20));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.clear();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyPoint myPoint = client.centerOfGravity();
            client.clear();
            client.add(myPoint);
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            client = client1;
            Refresh();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            client = client2;
            Refresh();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            client = client3;
            Refresh();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            client = client4;
            Refresh();
        }
    }

    
}
