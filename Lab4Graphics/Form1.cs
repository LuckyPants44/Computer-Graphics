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

namespace Lab4Graphics
{
    public partial class Form1 : Form
    {
        int scale = 40;
        Bitmap bmp;
        Point[] line = new Point[2];
        Point[] screen = new Point[2];

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
            DrawGrid();
        }

        //Рисуем сетку
        private void DrawGrid()
        {
            Graphics gr = Graphics.FromImage(bmp);
            Pen axesPen = new Pen(Brushes.Blue, 2);
            //Axes
            gr.DrawLine(axesPen, new Point(0, pictureBox.Height / 2), new Point(pictureBox.Width, pictureBox.Height / 2));
            gr.DrawLine(axesPen, new Point(pictureBox.Width / 2, 0), new Point(pictureBox.Width / 2, pictureBox.Height));
            //Grid
            for (int i = scale; i < pictureBox.Width / 2; i += scale)
            {
                gr.DrawLine(Pens.Black, new Point(pictureBox.Width / 2 + i, 0), new Point(pictureBox.Width / 2 + i, pictureBox.Height));
                gr.DrawLine(Pens.Black, new Point(pictureBox.Width / 2 - i, 0), new Point(pictureBox.Width / 2 - i, pictureBox.Height));
            }
            for (int i = scale; i < pictureBox.Height / 2; i += scale)
            {
                gr.DrawLine(Pens.Black, new Point(0, pictureBox.Height / 2 + i), new Point(pictureBox.Width, pictureBox.Height / 2 + i));
                gr.DrawLine(Pens.Black, new Point(0, pictureBox.Height / 2 - i), new Point(pictureBox.Width, pictureBox.Height / 2 - i));
            }
            pictureBox.Image = bmp;
        }

        private void textBoxKSX1_Enter(object sender, EventArgs e)
        {
            textBoxKSX1.Text = null;
            textBoxKSX1.ForeColor = Color.Black;
        }
        private void textBoxKSX2_Enter(object sender, EventArgs e)
        {
            textBoxKSX2.Text = null;
            textBoxKSX2.ForeColor = Color.Black;
        }
        private void textBoxKSY1_Enter(object sender, EventArgs e)
        {
            textBoxKSY1.Text = null;
            textBoxKSY1.ForeColor = Color.Black;
        }
        private void textBoxKSY2_Enter(object sender, EventArgs e)
        {
            textBoxKSY2.Text = null;
            textBoxKSY2.ForeColor = Color.Black;
        }

        private void textBoxKSX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[0].X = Convert.ToInt32(textBoxKSX1.Text);
            }
            catch { }
        }
        private void textBoxKSX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[1].X = Convert.ToInt32(textBoxKSX2.Text);
            }
            catch { }
        }
        private void textBoxKSY1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[0].Y = Convert.ToInt32(textBoxKSY1.Text);
            }
            catch { }
        }
        private void textBoxKSY2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                screen[1].Y = Convert.ToInt32(textBoxKSY2.Text);
            }
            catch { }
        }

        private void CohenSutherland_Click(object sender, EventArgs e)
        {
            Graphics gr = Graphics.FromImage(bmp);
            //Screen
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(0, pictureBox.Height / 2 - screen[0].Y * scale), new Point(pictureBox.Width, pictureBox.Height / 2 - screen[0].Y * scale));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(0, pictureBox.Height / 2 - screen[1].Y * scale), new Point(pictureBox.Width, pictureBox.Height / 2 - screen[1].Y * scale));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(pictureBox.Width / 2 + screen[0].X * scale, 0), new Point(pictureBox.Width / 2 + screen[0].X * scale, pictureBox.Height));
            gr.DrawLine(new Pen(Brushes.Red, 4), new Point(pictureBox.Width / 2 + screen[1].X * scale, 0), new Point(pictureBox.Width / 2 + screen[1].X * scale, pictureBox.Height));
            //Algorithm
            Algorithm alg = new Algorithm();
            string buf;
            List<DPoint> p = new List<DPoint>();
            buf = alg.CohenSutherland(screen, new DPoint(line[0]), new DPoint(line[1]));
            string[] buf1 = buf.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (buf1.Length == 4)
            {
                p.Add(new DPoint(Convert.ToDouble(buf1[0]), Convert.ToDouble(buf1[1])));
                p.Add(new DPoint(Convert.ToDouble(buf1[2]), Convert.ToDouble(buf1[3])));
            }
            else
            {
                for (int i = 0; i < buf1.Length; i++)
                {
                    if (buf1[i].Contains("!!!"))
                    {
                        p.Add(new DPoint(Convert.ToDouble(buf1[i - 1]), Convert.ToDouble(buf1[i].Remove(buf1[i].Length - 3, 3))));
                    }
                }
                if (p.Count == 1)
                {
                    if ((line[0].X >= screen[0].X) && (line[0].X <= screen[1].X) && (line[0].Y >= screen[0].Y) && (line[0].Y <= screen[1].Y))
                        p.Add(new DPoint(line[0]));
                    else p.Add(new DPoint(line[1]));
                }
            }
            gr.DrawLine(new Pen(Brushes.Green, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[1].Y * scale)));
            try
            {
                gr.DrawLine(new Pen(Brushes.Yellow, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + p[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - p[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + p[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - p[1].Y * scale)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            pictureBox.Image = bmp;
        }

        private void CyrusBeck_Click(object sender, EventArgs e)
        {
            string[] buf;
            Graphics gr = Graphics.FromImage(bmp);
            List<Point> points = new List<Point>();
            //Reading dots
            try
            {
                FileStream file = new FileStream("C://Users//1//Desktop//Лабы Быкова//4//Lab4Graphics//Lab4Graphics//Points.txt", FileMode.Open);
                StreamReader sr = new StreamReader(file);
                buf = sr.ReadToEnd().Split(' ', '\n', '\r');
                sr.Close();
                for (int i = 0; i < buf.Length - 1; i += 3)
                {
                    points.Add(new Point(Convert.ToInt32(buf[i]), Convert.ToInt32(buf[i + 1])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия файла!" + ex.Message);
            }
            //Drawing points
            for (int i = 0; i < points.Count; i++)
            {
                if (i != points.Count - 1)
                {
                    gr.DrawLine(new Pen(Brushes.Red, 2), new Point(pictureBox.Width / 2 + points[i].X * scale, pictureBox.Height / 2 - points[i].Y * scale), new Point(pictureBox.Width / 2 + points[i + 1].X * scale, pictureBox.Height / 2 - points[i + 1].Y * scale));
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Red, 2), new Point(pictureBox.Width / 2 + points[0].X * scale, pictureBox.Height / 2 - points[0].Y * scale), new Point(pictureBox.Width / 2 + points[i].X * scale, pictureBox.Height / 2 - points[i].Y * scale));
                }
                pictureBox.Image = bmp;
            }
            //Algorithm
            Algorithm alg = new Algorithm();
            List<DPoint> result = new List<DPoint>();
            result = alg.CyrusBeck(new DPoint(line[0]), new DPoint(line[1]), points);
            gr.DrawLine(new Pen(Brushes.Green, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[0].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[0].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + line[1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - line[1].Y * scale)));

            if (result.Count > 0)
            {
                for (int k = 0; k < result.Count; k++)
                {
                    gr.DrawRectangle(new Pen(Brushes.Black, 4), Convert.ToInt32(pictureBox.Width / 2 + result[k].X * scale), Convert.ToInt32(pictureBox.Height / 2 - result[k].Y * scale), 2, 2);
                }
            }
            gr.DrawLine(new Pen(Brushes.Yellow, 4), new Point(Convert.ToInt32(pictureBox.Width / 2 + result[result.Count - 1].X * scale), Convert.ToInt32(pictureBox.Height / 2 - result[result.Count - 1].Y * scale)), new Point(Convert.ToInt32(pictureBox.Width / 2 + result[result.Count - 2].X * scale), Convert.ToInt32(pictureBox.Height / 2 - result[result.Count - 2].Y * scale)));
            pictureBox.Image = bmp;
        }


        private void textBoxLineX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[0].X = Convert.ToInt32(textBoxLineX1.Text);
            }
            catch { }
        }
        private void textBoxLineY1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[0].Y = Convert.ToInt32(textBoxLineY1.Text);
            }
            catch { }
        }
        private void textBoxLineX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[1].X = Convert.ToInt32(textBoxLineX2.Text);
            }
            catch { }
        }
        private void textBoxLineY2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                line[1].Y = Convert.ToInt32(textBoxLineY2.Text);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
            DrawGrid();
        }
    }
}
