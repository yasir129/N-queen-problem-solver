using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class help : MetroFramework.Forms.MetroForm
    {
        OpenFileDialog ofd;
        public help()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = "test.txt";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }
    }
}
