using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace little_bits_drive_me_crazy
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        GravityPoint point1; 
        //GravityPoint point2;
        public Form1()
        {
            InitializeComponent();
            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);
            
            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = DisPic.Width / 2,
                Y = DisPic.Height / 2,
            };
            
            emitters.Add(this.emitter);
            
            point1 = new GravityPoint
            {
                X = DisPic.Width / 2 + 100,
                Y = DisPic.Height / 2,
            };
            emitter.impactPoints.Add(point1);
            /*
            point2 = new GravityPoint
            {
                X = DisPic.Width / 2 - 100,
                Y = DisPic.Height / 2,
            };

            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
            */



        }
        private int MousePositionX = 0;
        private int MousePositionY = 0;
        private void DisPic_Click(object sender, EventArgs e)
        {
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(DisPic.Image))
            {
                g.Clear(Color.Black); 
                emitter.Render(g);
            }
            DisPic.Invalidate();
        }
        

        

        private void DisPic_MouseMove(object sender, MouseEventArgs e)
        {
             
            //emitter.MousePositionX = e.X;
            //emitter.MousePositionY = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;

        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            //point2.Power = tbGraviton2.Value;
        }

        private void DisPic_MouseClick(object sender, MouseEventArgs e)
        {
            point1.X = e.X;
            point1.Y = e.Y;
        }
    }
}
