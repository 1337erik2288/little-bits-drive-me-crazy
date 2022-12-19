﻿using System;
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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        public Form1()
        {
            InitializeComponent();

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

            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);
            /*
            emitter = new TopEmitter
            {
                Width = DisPic.Width,
                GravitationY = 0.25f,
                
            };
            
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(DisPic.Width * 0.25),
                Y = DisPic.Height / 2
            });

            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = DisPic.Width / 2,
                Y = DisPic.Height / 2
            });

            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(DisPic.Width * 0.75),
                Y = DisPic.Height / 2
            });
            */

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

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
        }
    }
}
