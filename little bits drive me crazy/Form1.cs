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
        public Form1()
        {
            InitializeComponent();

            DisPic.Image = new Bitmap(DisPic.Width, DisPic.Height);
        }

        private void DisPic_Click(object sender, EventArgs e)
        {

        }
    }
}
