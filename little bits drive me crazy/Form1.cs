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
        Emitter emitter = new Emitter();
        public Form1()
        {
            InitializeComponent();

            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);

            emitter.gravityPoints.Add(new Point(
                DisPic.Width / 2, 
                DisPic.Height / 2
                ));

        }

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
        

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        private void DisPic_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
