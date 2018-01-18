using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApplication10
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public int count12 = 0;
        public int lines;
        public int n;
        public int[,] a = new int[100, 100];
        public Form1()
        {
            InitializeComponent();
        }
        bool bestplace(int r, int c)
        {
            int i, j;
            for (i = 0; i < c; i++)
            {
                if (a[r, i] == 1)
                {
                    return false;
                }
            }
            for (i = r, j = c; i >= 0 && j >= 0; i--, j--)
            {
                if (a[i, j] == 1)
                {
                    return false;
                }
            }
            for (i = r, j = c; i < n && j >= 0; i++, j--)
            {
                if (a[i, j] == 1)
                {
                    return false;
                }
            }
            r = 0;
            c = 0;
            return true;
        }

        bool Checking(int all)
        {
            if (all >= n)
            {
                return true;
            }
            for (int i = 0; i < n; i++)
            {
                if (bestplace(i, all))
                {
                    a[i, all] = 1;
                    if (Checking(all + 1))
                    {
                        return true;
                    }
                    a[i, all] = 0;
                }
            }
            return false;
        }
        bool Checking1(int all)
        {
            if (all >= n)
            {
                return true;
            }
            for (int i = 0; i < n; i++)
            {
                if (bestplace(i, all))
                {
                    a[i, all] = 1;
                    if (Checking1(all + 1))
                    {
                        write();
                        count12++;
                    }
                    a[i, all] = 0;
                }
            }
            return false;
        }
        public void write()
        {
            using (StreamWriter s = File.AppendText("output.txt"))
            {
                s.WriteLine("\nSOLUTION NO {0}\n", count12);
                s.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (a[i, j] == 1)
                        {
                            s.Write("Q ");
                        }
                        else
                        {
                            s.Write("- ");
                        }
                    }
                    s.WriteLine();
                }
            }
        }
        void print()
        {
            count12++;
            Graphics gr = panel1.CreateGraphics();
            int xaxis = panel1.Width / lines;
            int yaxis = panel1.Height / lines;
            int x = 0;
            int y = 0;
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    if (a[i, j] == 1)
                    {
                        PictureBox picture = new PictureBox
                        {
                            Name = "pictureBox",
                            Size = new Size(xaxis, xaxis),
                            Location = new Point(x, y),
                            ImageLocation = @"queen.jpeg",
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        panel1.Controls.Add(picture);
                        x += xaxis;
                    }
                    else
                    {
                        x += xaxis;
                    }
                }
                x = 0;
                y += yaxis;

            }
            x = 0;
            y = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string data;
            data = File.ReadAllText("input.txt");
            lines = int.Parse(data);
            n = lines;
            Graphics h = panel1.CreateGraphics();
            SolidBrush bla = new SolidBrush(Color.Black);
            SolidBrush White = new SolidBrush(Color.White);
            int x = 0;
            int y = 0;
            int spacex = panel1.Width / lines;
            int spacey = panel1.Height / lines;
            panel1.Height = spacex * lines;
            panel1.Width = spacex * lines;
            h.FillRectangle(bla, x, y, panel1.Height, panel1.Width);
            for (int u = 0; u < n; u++)
            {
                for (int R = 0; R < n; R++)
                {
                    x += spacex;
                    if (u % 2 == 0 && R % 2 == 0)
                    {
                        h.FillRectangle(White, x, y, spacex, spacey);
                    }
                }
                x = 0;
                y += spacey;
            }
            x = 0;
            y = 0;
            for (int u = 0; u < n + 2; u++)
            {
                for (int R = 0; R < n + 2; R++)
                {
                    if (u % 2 != 0 && R % 2 != 0)
                    {
                        h.FillRectangle(White, x, y, spacex, spacey);
                        x = x + (spacex * 2);
                    }
                }
                x = 0;
                y += spacey;
            }
            x = 0;
            y = 0;
            Checking(0);
            print();
            a = new int[100, 100];
            Checking1(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            help h = new help();
            h.Show();
        }

    }
}
