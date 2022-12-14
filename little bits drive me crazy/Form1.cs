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
        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();

            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);
            /*
            for (var i = 0; i < 500; i++)
            {
                var particle = new Particle();

                particle.X = DisPic.Image.Width / 2;
                particle.Y = DisPic.Image.Height / 2;

                particles.Add(particle);    
            }
            */
        }

        private void DisPic_Click(object sender, EventArgs e)
        {

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();
            using (var g = Graphics.FromImage(DisPic.Image))
            {
                g.Clear(Color.White);
                Render(g);
            }
            DisPic.Invalidate();
        }
        private void UpdateState()
        {
            foreach(var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rnd.Next(100);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particle.Direction = Particle.rnd.Next(360);
                    particle.Speed = 1 + Particle.rnd.Next(10);
                    particle.Radius = 2 + Particle.rnd.Next(10);
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y += (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    var particle = new Particle();
                    particle.X = MousePositionX;
                    particle.Y= MousePositionY;
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
        }
        private void Render(Graphics g)
        {
            foreach(var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void DisPic_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
    }
}
