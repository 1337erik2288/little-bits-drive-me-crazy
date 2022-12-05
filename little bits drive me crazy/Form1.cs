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
        public Form1()
        {
            InitializeComponent();

            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);

            for (var i = 0; i < 500; i++)
            {
                var particle = new Particle();

                particle.X = DisPic.Image.Width / 2;
                particle.Y = DisPic.Image.Height / 2;

                particles.Add(particle);    
            }
        }

        private void DisPic_Click(object sender, EventArgs e)
        {

        }
    }
}